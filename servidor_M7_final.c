/*Servidor del proyecto del grupo 7
Version: 5
Fecha: 21/06/2022
Asignatura: Sistemes Operatius
Profesor: M. Valero
Autores: M. Jawhari, G. Leon, J. Martinez, D. Mur.
Universitat Politecnica de Catalunya
*/
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <pthread.h>
#include<mysql.h>

int contador = 0;
int i = 0;
int sockets[100];
int IDjug;
int MAXID;

//Estructura necesaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

typedef struct{
char nombre[30];
int socket;
}Conectado;

typedef struct{
Conectado conectados[100];
int num;
}ListaConectados;

ListaConectados milistaConectados;

typedef struct{
	int Id;
	char jugadores[200];
	int numerojugadores;
	int contadorrespuestas;
	int partidaLista;
	int numeroJugadoresReales;
}Partida;

typedef struct{
	Partida partidas[100];
	int num;
}ListaPartidas;

ListaPartidas milistaPartidas;

//Devueleve la posicion del nombre en la lista que se pasa como parametro o -1 si no se ha encontrado
int DamePosicion (ListaConectados *milista, char nombre[20]){
	int i=0;
	int encontrado = 0;
	while ((i< milista->num) && encontrado==0)
	{
		if (strcmp(milista->conectados[i].nombre, nombre) == 0)
			encontrado =1;
		if (encontrado == 0)
			i=i+1;
	}
	if (encontrado != 0)
		return i;
	else
		return -1;
}

//Devuelve el numero de socket del jugador. Devuelve -1 si no lo ha encontrado
int DameSocket (ListaConectados *milista, char nombre[20]){
	int i=0;
	int encontrado = 0;
	while ((i< milista->num) && !encontrado)
	{
		if (strcmp(milista->conectados[i].nombre, nombre) == 0)
			encontrado =1;
		if (!encontrado)
			i=i+1;
	}
	if (encontrado)
		return milista->conectados[i].socket;
	else
		return -1;
}


//Anade un jugador a la lista de conectados. Devuelve -1 si la lista esta llena.
int PonerConectados(ListaConectados *milistaConectados,char nombre[20],int socket)
{ 
	if (milistaConectados->num==100)
		return -1;
	else{
		pthread_mutex_lock( &mutex);
		strcpy(milistaConectados->conectados[milistaConectados->num].nombre,nombre);
		milistaConectados->conectados[milistaConectados->num].socket=socket;
		milistaConectados->num=milistaConectados->num + 1;
		pthread_mutex_unlock( &mutex);
		return 0;
	}
}

//Retorna 0 si elimina y -1 si el usuario no esta en la lista
int QuitarDeConectados(ListaConectados *milistaConectados,char nombre[20])
{
	printf("Nombre Que se le envÌa a DamePosicion: %s\n", nombre);
	int pos = DamePosicion(milistaConectados, nombre);
	printf("DamePosicion (quitardeconectados) devuelve: %d\n", pos);
	if (pos == -1)
		return -1;
	else {
		int i = pos;
		if (pos == 0 && milistaConectados->num == 1) {
			printf("Se mete en cas0: %d; i: %d\n", pos, i);
			strcpy(milistaConectados->conectados[i].nombre, "");
			//milistaConectados->conectados[i].socket = 0;
			milistaConectados->num =0;
		}
		else {
			for(i = pos; i < milistaConectados->num-1; i++)
			{
				printf("Se mete en bucle con : %d; i: %d\n", pos, i);
				strcpy(milistaConectados->conectados[i].nombre, milistaConectados->conectados[i+1].nombre);
				milistaConectados->conectados[i].socket = milistaConectados->conectados[i+1].socket;
			}
			milistaConectados->num--;
		}
		
		return 0;
		}
	}

//esta funciÛn devuelve los conectados, poniendo uno en cada lÌnea.
void DameConectados(ListaConectados *milistaConectados, char conectados[512])
{
	/*int i;
	strcpy(conectados,"7/");
	for(i =0;i<milistaConectados->num;i++)
	{
		sprintf(conectados,"%s%s-",conectados,milistaConectados->conectados[i].nombre);
	}
	printf("%s\n",conectados);*/
	int i =0;
	//strcpy(conectados,"7/");
	//strcpy (conectados, "-");
	strcpy(conectados, "");
	//printf("Los conectados (segun DameConectados-pre) son: %s\n", conectados);
	for (i=0; i< milistaConectados->num; i++)
	{
		sprintf (conectados, "%s%s-", conectados, milistaConectados->conectados[i].nombre);
		printf("%s\n", conectados);
	}
	//printf("Los conectados (segun DameConectados-post) son: %s\n", conectados);
	return;
}



//Crea una partida y la anade a la lista de partidas. Devuelve el ID de la partida o -1 si la lista esta llena.
int CrearPartida(ListaPartidas *milistaPartidas, char nombre[20], int numerojugadores, int numeroJugadoresReales){
	if(milistaPartidas->num== 100){
		printf("La lista de partidas esta llena\n");
		return -1;
	}
	else{	
		sprintf(milistaPartidas->partidas[milistaPartidas->num].jugadores, "/%s/", nombre);
		milistaPartidas->partidas[milistaPartidas->num].Id = milistaPartidas->num;
		milistaPartidas->partidas[milistaPartidas->num].numerojugadores = numerojugadores;
		milistaPartidas->partidas[milistaPartidas->num].numeroJugadoresReales = numeroJugadoresReales;
		milistaPartidas->partidas[milistaPartidas->num].contadorrespuestas=1;
		milistaPartidas->partidas[milistaPartidas->num].partidaLista=0;
		milistaPartidas->num= milistaPartidas->num + 1;
		int Id = (milistaPartidas->num-1);
		return Id;
		
	}
}


/*
Agrega un jugador a la partida en la lista de partidas que se pasa como parametro.
Devuelve -1 si no se ha encontrado la partida
Devuelve 0 si se ha agregado exitosamente al jugador
*/
int PonerEnPartida(ListaPartidas *milistaPartidas, int Id, char jugador[20]){
	int i=0;
	//primero se busca la partida en la lista de partidas
	int encontrado=0;
	while((i<milistaPartidas->num) && (!encontrado)){
		if(milistaPartidas->partidas[i].Id == Id){
			encontrado = 1;
		}
		else{
			i++;
		}
	}
	if (encontrado){
		strcat (milistaPartidas->partidas[i].jugadores , jugador);
		strcat (milistaPartidas->partidas[i].jugadores , "/");
		printf("Los jugadores en la partida son: %s\n", milistaPartidas->partidas[i].jugadores);
		return 0;
	}
	else{
		return -1;
	}
}

void *AtenderCliente (void *socket)
{   
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	//int socket_conn = * (int *) socket;

	char peticion[512];  //inicializacion de variables de peticion-respuesta
	char respuesta[512];
	int ret;
	
	int terminar =0;
	/* Fin del bloque de inicializacion del socket*/
	/*Inicializacion del bloque de consulta SQL*/
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char nombre[20];
	char consulta [1000];
	
	conn = mysql_init(NULL); //Creamos una conexion al servidor MYSQL
	if (conn==NULL) {
		printf("Error al crear la conexion 1 %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//else printf("se ha inicializado la conexi√≥n 1\n");
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "M7_BBDD",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion 2: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	/* Entramos en un bucle para atender todas las peticiones de este cliente
	hasta que se desconecte*/
	while (terminar ==0) {
		//recepcion de la peticion
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		peticion[ret]='\0';
		printf ("Peticion: %s\n",peticion);// Bucle infinito

		//gestion de la peticion
		char* p; 
		p= strtok( peticion, "/");
		int codigo =  atoi (p);
		char nombre[20];
		//char usuarioconn[20];
		char contrasenya[20];
		int numerojugadores;
		int numeroInvitados;
		int numForm;
		char conectados[512];
		
		if ((codigo !=0 && codigo != 99 &&codigo != 11)) {
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
		}
		
		//funcion de desconexiÛn para jugadores logueados
		if (codigo == 0)
		{
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
			if (strcmp(nombre, "not_logged_user") != 0) {
				pthread_mutex_lock(&mutex);
				int e = QuitarDeConectados(&milistaConectados, nombre);
				//printf("quitar devuelve %d\n", e);
				DameConectados(&milistaConectados, conectados);
				printf("Los conectados son: %s\n", conectados);
				pthread_mutex_unlock(&mutex);
				if (e == 0)
					printf("Eliminado correctamente\n"); 
				else
					printf("No eliminado\n");  
			}
			sprintf(respuesta, "0/Desconectado");
			printf("%s\n", respuesta);
			write(sock_conn,respuesta,strlen(respuesta));
			//terminar = 1;
		}

		if (codigo==90) { 
			//codigo5modif
			p= strtok(NULL,"/");
			strcpy (contrasenya, p);
			printf("Contrase√±a: %s\n",contrasenya);
			sprintf(consulta, "DELETE FROM jugador WHERE jugador.NOMBRE ='%s' AND jugador.CONTRASENYA ='%s';", nombre, contrasenya);
			
			err = mysql_query(conn,consulta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
				exit (1);
				}
			//resultado = mysql_store_result (conn);
			//row = mysql_fetch_row (resultado);
			//printf("El socket del jugador es: %d\n", sock_conn);
			QuitarDeConectados(&milistaConectados, nombre);
			sprintf(respuesta, "90/Baja exitosa\n");
			//strcpy(usuarioconn, nombre);
			printf("El jugador %s ha sido eliminado de la base de datos.\n", nombre);
		}

		
		//Consulta para  saber la cantidad de partidas que ha ganado una persona
		if (codigo==1) { 
			int num = 0;
			sprintf(consulta,"SELECT COUNT(resultados.PUNTOS) FROM partida,jugador, resultados \n");
			strcat(consulta,"WHERE (resultados.ID_J = jugador.ID \nAND ");
			strcat(consulta,"jugador.NOMBRE = partida.GANADOR \nAND resultados.ID_P = partida.ID \nAND ");
			sprintf(consulta,"%sjugador.NOMBRE = '%s');", consulta, nombre);
			err=mysql_query (conn, consulta); 
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
			}
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			if (row == NULL)
				sprintf (respuesta, "1/El usuario a√∫n no ha ganado una partida\n");
			else {
				num = atoi(row[0]);
				sprintf(respuesta, "1/El jugador %s ha ganado %d partidas\n", nombre, num);
			}
		}
		//Consulta para saber en qu√© escenarios 2 jugadores han jugado juntos
		if (codigo==2) { 
			sprintf(respuesta,"2/");
			char nombre2[20];
			char tablero[20];
			p = strtok(NULL, "/");
			strcpy (nombre2, p);
			printf ("Nombre2: %s\n", nombre2);
			sprintf(consulta,"SELECT resultados.ID_P, partida.TABLERO FROM jugador,resultados,partida \n");
			strcat(consulta,"WHERE resultados.ID_P = partida.ID AND \n");
			sprintf(consulta,"%sjugador.NOMBRE = '%s' AND \n", consulta, nombre);
			strcat(consulta,"jugador.ID = resultados.ID_J AND \n");
			strcat(consulta,"resultados.ID_P IN (SELECT resultados.ID_P FROM \n");
			strcat(consulta,"jugador,resultados WHERE \n");
			sprintf(consulta,"%sjugador.NOMBRE = '%s' AND \n", consulta, nombre2);
			strcat(consulta,"jugador.ID = resultados.ID_J);\n");
			printf(consulta);
			err=mysql_query (conn, consulta); 
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
			}
			resultado = mysql_store_result (conn);
			int terminado = 0;
			int ninguno =0;
			while(terminado==0) {
				row = mysql_fetch_row (resultado);
				if (row == NULL) {
					terminado=1;
					if(ninguno == 0) 
						sprintf(respuesta, "%sEn ningun sitio aun, colega.\n",respuesta);
				}
				else {
					sprintf (tablero, "%s", row[1]);
					sprintf(respuesta, "%s%s\n",respuesta, tablero);
					ninguno++;
				}
			}
			printf(respuesta);
		}
		
		//Consulta para  saber en qu√© escenario he obtenido mas puntos
		if (codigo==3) { 
			sprintf(consulta,"SELECT partida.ID, partida.TABLERO, resultados.PUNTOS\n");
			strcat(consulta,"FROM jugador,partida,resultados WHERE\n");
			sprintf(consulta,"%s (jugador.NOMBRE = '%s' AND\n", consulta, nombre);
			strcat(consulta,"jugador.ID = resultados.ID_J AND\n");
			strcat(consulta,"resultados.ID_P = partida.ID)\n");
			strcat(consulta,"ORDER BY resultados.PUNTOS DESC;\n");
			err=mysql_query (conn, consulta); 
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
			}
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			if (row == NULL)
				sprintf (respuesta, "3/A√∫n no has obtenido puntos\n");
			else {
				sprintf (resultado, "%s", row[1]);
				printf("%s\n", resultado);
				strcpy(respuesta, "3/El escenario donde has obtenido mas puntos es: ");
				sprintf(respuesta, "%s%s\n", respuesta, resultado);
			}
		}
		
		//Consulta para saber el tablero de posiciones
		if (codigo==4) { 
			int num = 0;
			sprintf(respuesta,"4/\n");
			sprintf(consulta,"SELECT jugador.NOMBRE, jugador.PUNTOSACUM \n");
			strcat(consulta,"FROM jugador ORDER BY jugador.PUNTOSACUM DESC;\n");
			err=mysql_query (conn, consulta); 
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
			}
			resultado = mysql_store_result (conn);
			int terminado = 0;
			while(terminado==0) {
				
				row = mysql_fetch_row (resultado);
				if (row == NULL)
					terminado=1;
				else {
					sprintf (nombre, "%s", row[0]);
					num = atoi(row[1]);
					sprintf(respuesta, "%s%s ---- %d puntos\n",respuesta, nombre, num);
				}
			}
			printf(respuesta);
		}
		
		//funcion de login de un usuario
		if (codigo==5) { 
			p= strtok(NULL,"/");
			strcpy (contrasenya, p);
			printf("Contrase√±a: %s\n",contrasenya);
			sprintf(consulta, "SELECT jugador.ID FROM jugador WHERE jugador.NOMBRE ='%s' AND jugador.CONTRASENYA ='%s';", nombre, contrasenya);
			
			err = mysql_query(conn,consulta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			if (row == NULL)
				sprintf (respuesta, "52/No existe el usuario y/o la contrasenya es incorrecta\n");
			else {
				printf("El socket del jugador es: %d\n", sock_conn);
				PonerConectados(&milistaConectados, nombre, sock_conn);
				sprintf(respuesta, "51/Login exitoso\n");
				//strcpy(usuarioconn, nombre);
			}
			
		}
		//funcion de registro del usuario
		if(codigo==6) { 
			p = strtok(NULL,"/");
			strcpy (contrasenya, p);
			printf("Contrase√±a: %s\n",contrasenya);
			int err=0;
			char con[300];
			sprintf(con, "SELECT COUNT(jugador.NOMBRE) from jugador WHERE jugador.NOMBRE = '%s'",nombre);
			err = mysql_query(conn,con);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			int num = atoi (row[0]);
			if (num!=0)
				sprintf(respuesta, "6/El nombre de usuario ya existe\n");
			else {
				sprintf(con, "SELECT COUNT(ID) FROM jugador WHERE ID IS NOT NULL;");
				err = mysql_query(conn,con);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				if (row == NULL)
					printf ("No se han obtenido datos en la consulta\n");
				else {
					int num = atoi(row[0]); 
					num++;
					sprintf(con,"INSERT INTO jugador VALUES(%d,'%s','%s',0);", num, nombre, contrasenya);
					err = mysql_query(conn,con);
					if (err!=0)
					{
						printf ("Error al registrar el jugador %u %s\n",
								mysql_errno(conn), mysql_error(conn));
						exit (1);
					}
					else {
						sprintf(consulta, "SELECT jugador.ID FROM jugador WHERE jugador.NOMBRE ='%s' AND jugador.CONTRASENYA ='%s';", nombre, contrasenya);
						
						err = mysql_query(conn,consulta);
						if (err!=0) {
							printf ("Error al consultar datos de la base %u %s\n",
									mysql_errno(conn), mysql_error(conn));
							exit (1);
						}
						resultado = mysql_store_result (conn);
						row = mysql_fetch_row (resultado);
						IDjug = atoi(row[0]);
						printf("El ID del jugador es: %d\n", IDjug);
						//PonerConectados(&milistaConectados, nombre, IDjug);
						sprintf(respuesta, "6/Has sido registrado exitosamente\n");
					}
				}
			}
		}
		
		//Invitacion a partida
		if (codigo == 8) {
			printf("CÛdigo: %d\n",codigo);
			sprintf(respuesta, "8/Recibido\n");
			char invitado[30];
			strcpy(nombre, p);
			printf("Nombre del anfitrion: %s\n",nombre);
			p = strtok(NULL,"/");
			numeroInvitados= atoi(p);
			numerojugadores = numeroInvitados +1;
			printf("Numero jugadores: %d\n", numerojugadores);
			int numeroJugadoresReales = numerojugadores;
			pthread_mutex_lock(&mutex);
			int res1 = CrearPartida(&milistaPartidas, nombre, numerojugadores, numeroJugadoresReales); 
			pthread_mutex_unlock(&mutex);
			printf("El ID de la Partida es: %d\n", res1);
			if (res1 == -1){
				printf("La lista esta llena\n");
			}
			else{
				//printf("Aqui si que entra\n");
				//comprobado hasta aquÌ no peta
				int i=0;
				while(i<numeroInvitados){
					p = strtok(NULL,"/");
					strcpy(invitado, p);
					printf("Jugador Invitado n∫%d: %s\n", i+1, invitado);
					pthread_mutex_lock(&mutex);
					int socketjugador = DameSocket(&milistaConectados, invitado);
					pthread_mutex_unlock(&mutex);
					printf("Socket del Invitado n∫d: %d\n", socketjugador, i+1);
					if (socketjugador != 0){
						sprintf(respuesta, "8/%s/%d", nombre, res1);
						printf("Invitacion: %s\n", respuesta);
						write(socketjugador,respuesta,strlen(respuesta));
					}
					else
						printf("Error en la Invitacion");
					i++;
				}
			}
		}
		
		//Codigo para aceptar una invitacion a una partida
		if (codigo == 9){
			printf("Codigo: %d\n",codigo);
			sprintf(respuesta, "9/Recibido\n");
			printf("%s\n",peticion);
			//n√∫mero de formulario
			p = strtok( NULL, "/");
			numForm =  atoi(p);
			printf("Formulario: %d\n",numForm);
			//anfitrion
			char anfitrion[20];
			//p = strtok(NULL,"/");
			strcpy(anfitrion, p);
			printf("Nombre del Anfitrion: %s\n",anfitrion);
			//invitado que esta respondiendo
			char invitado9[20];
			p = strtok(NULL,"/");
			strcpy(invitado9, p);
			printf("Nombre del Invitado: %s\n",invitado9);
			//id de la partida
			p = strtok(NULL,"/");
			int Id= atoi(p);
			printf("Id de la parida: %d\n",Id);
			//1 si acepta, 0 si no
			p = strtok(NULL,"/");
			int acepta= atoi(p);
			
			pthread_mutex_lock(&mutex);
			int socketjugador = DameSocket(&milistaConectados, invitado9);
			pthread_mutex_unlock(&mutex);
			printf("Socket: %d\n", socketjugador);
			
			if(acepta == 0){
				printf("El jugador no ha aceptado la partida\n");
				sprintf(respuesta, "9/%d/NO", numForm);
				printf("Acepta?: %s\n", respuesta);
				//pthread_mutex_lock(&mutex);
				//write(socketjugador,respuesta,strlen(respuesta));
				//pthread_mutex_unlock(&mutex);
			}
			else{
				pthread_mutex_lock(&mutex);
				int res= PonerEnPartida(&milistaPartidas, Id, invitado9);
				pthread_mutex_unlock(&mutex);
				if (res == 0){
					printf("Anadido a la partida\n");
					sprintf(respuesta, "9/%d/SI", numForm);
					printf("Anadido a la partida: %s\n", respuesta);
					//pthread_mutex_lock(&mutex);
					//write(socketjugador,respuesta,strlen(respuesta));
					//pthread_mutex_unlock(&mutex);
				}
			}
			
			write(socketjugador,respuesta,strlen(respuesta));
			milistaPartidas.partidas[Id].contadorrespuestas = milistaPartidas.partidas[Id].contadorrespuestas + 1;
			
			//funcion encargada de enviar los jugadores de la partida
			if(milistaPartidas.partidas[Id].contadorrespuestas >= milistaPartidas.partidas[Id].numerojugadores)
			{
				milistaPartidas.partidas[Id].partidaLista=1;
				char jugadores[200];
				char sockets[4];
				strcpy(jugadores, milistaPartidas.partidas[Id].jugadores);
				char jugador[20];
				char *u;
				u = strtok(jugadores, "/");
				strcpy(jugador, u);
				pthread_mutex_lock(&mutex);
				sockets[0] = DameSocket(&milistaConectados, jugador);
				pthread_mutex_unlock(&mutex);
				printf("Nombre del Jugador 0: %s\n", jugador);
				
				for(int i=1; i<milistaPartidas.partidas[Id].numerojugadores;i++)
				{	
					printf("Se mete en este bucle\n");
					u = strtok(NULL, "/");
					strcpy(jugador, u);
					printf("Nombre del Jugador %d: %s\n", i, jugador);
					pthread_mutex_lock(&mutex);
					sockets[i] = DameSocket(&milistaConectados, jugador);
					pthread_mutex_unlock(&mutex);
					
				}
				sprintf(respuesta, "10%s", milistaPartidas.partidas[Id].jugadores);
				printf("Respuesta: %s\n", respuesta);
				int numeroJugadoresReales = milistaPartidas.partidas[Id].numerojugadores;
				milistaPartidas.partidas[Id].numeroJugadoresReales = numeroJugadoresReales;
				if(milistaPartidas.partidas[Id].numerojugadores<4) {
					for(int i = milistaPartidas.partidas[Id].numerojugadores; i<4; i++) {
						pthread_mutex_lock(&mutex);
						int res= PonerEnPartida(&milistaPartidas, Id, "null_player");
						pthread_mutex_unlock(&mutex);
						sprintf(respuesta, "%s%s/", respuesta, "null_player");
					}
				}
				
		
				for(int i=0; i<numeroJugadoresReales;i++)
				{	
					write(sockets[i],respuesta,strlen(respuesta));
				}
				
			}
		}
		
		//Jugada que envia a los otros jugadores
		if (codigo == 11) {
			printf("CÛdigo: %d\n",codigo);
			//sprintf(respuesta, "11/Recibido\n");
			int nForm;
			p = strtok(NULL,"/");
			nForm = atoi (p);
			printf("NForm: %d\n",nForm);
			char jugadorjuega[20];
			p = strtok(NULL,"/");
			strcpy(jugadorjuega, p);
			printf("Nombre del jugador que mueve: %s\n",jugadorjuega);
			int id;
			p = strtok(NULL,"/");
			
			id = atoi (p);
			printf("Id: %d\n",id);
			int num;
			p = strtok(NULL,"/");
			num = atoi (p);
			printf("Num de movimiento: %d\n",num);
			
			char jugadores[200];
			strcpy(jugadores, milistaPartidas.partidas[id].jugadores);
			printf("Jugadores: %s\n", jugadores);
			p = strtok(jugadores,"/");
			int socketjugador = DameSocket(&milistaConectados, p);
			sprintf (respuesta, "12/%d/%s/%d/%d/", nForm, jugadorjuega, id, num);
			printf("Respuesta: %s\n", respuesta);
			//write(socketjugador,respuesta,strlen(respuesta));
			int numeroJugadoresReales = milistaPartidas.partidas[id].numeroJugadoresReales;
			printf("Num jugadores reales: %d\n", numeroJugadoresReales);
			for(int i=0; i<numeroJugadoresReales;i++)
			{	
				if(sockets[i]!= DameSocket(&milistaConectados, jugadorjuega)) {
					write(sockets[i],respuesta,strlen(respuesta));
					printf("Written to socket: %d\n", sockets[i]);
					printf("Response was: %s\n", respuesta);
				}
			}
		}

		if (codigo == 33){
			//p = strtok( NULL, "/");
			//numForm =  atoi(p);
			char texto[500];
			p = strtok(NULL,"/");
			strcpy(texto, p);
			//char usuario[20];
			//p = strtok(NULL,"/");
			//strcpy(usuario, p);
			//p = strtok(NULL,"/");
			//int Id= atoi(p);
			
			//char jugadores[200];
			//strcpy(jugadores, milistaPartidas.partidas[Id].jugadores);
			
			//char *u = strtok(jugadores,"/");
			//while (u != NULL)
			//{
				//int socketjugador = DameSocket(&milistaConectados, u);
				sprintf (respuesta, "33/%s/%s",nombre, texto);
				printf("Respuesta: %s\n", respuesta);
				int j;
				for (j=0; j<i;j++)
					write (sockets[j], respuesta, strlen(respuesta));
			//	write(socketjugador,respuesta,strlen(respuesta));
			//	u = strtok(NULL,"/");
			//}
		}
		
		
		

		
		//Envio de respuesta para todos los codigos excepto el de desconexion
		// o los que ya escriben por su cuenta.
		if (codigo !=0 && codigo !=8 && codigo !=9 && codigo !=10 && codigo !=11 && codigo !=33) {
			printf ("Respuesta: %s\n", respuesta);
			write (sock_conn,respuesta, strlen(respuesta));
		}
		
		//Funciones para los codigos relacioandos a la lista de conectados
		if ((codigo == 0) || (codigo ==5) || (codigo ==90))
		{
			pthread_mutex_lock( &mutex);
			char notificacion[512];
			DameConectados(&milistaConectados, conectados);
			strcpy (notificacion, "7/");
			strcat(notificacion, conectados);
			pthread_mutex_unlock (&mutex);
			//printf("Los conectados (segun atenderCliente) son: %s\n", notificacion);
			//printf("%s\n",conectados);
			int j;
			for (j=0; j<i;j++)
				write (sockets[j], notificacion, strlen(notificacion));
			
		}
		
		//codigo de debugging
		if (codigo == 99) {
			printf("Mensaje a procesar en cliente: %s", p);
		}
		
		if (codigo == 0) 
			terminar=1;
		
	}
			
	// Se acabo el servicio para este cliente
	close(sock_conn);
}

/*Nueva funcion principal*/
int main(int argc, char *argv[])
{
	/* Inicializacin del socket del servidor.
	Este bloque servir· para crear el socket que comunicar· al
	servidor con los m˙ltiples clientes*/
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0) // Abrimos el socket
		printf("Error creando socket");
	// Bind al puerto
	memset(&serv_adr, 0, sizeof(serv_adr));// inicializa a cero serv_addr
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY); // asocia el socket a cualquiera de las IP de la maquina. 
	
	serv_adr.sin_port = htons(50023); // establecemos el puerto de escucha
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error en el bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	char peticion[512];  //inicializaciÛn de variables de peticiÛn-respuesta
	char respuesta[512];
	/* Fin del bloque de inicializaciÛn del socket*/
	
	pthread_t thread;
	for (;;) {
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
	
		
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		// Crear thead y decirle lo que tiene que hacer
		
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i=i+1;
		
	}

}
