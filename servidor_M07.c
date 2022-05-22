/*Servidor del proyecto del grupo 7
Version: 3
Fecha: 02/05/2022
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
int i;
i=0;
int sockets[100];
int IDjug;
int MAXID;

//Estructura necesaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

typedef struct{
char nombre[30];
int ID;
}Conectado;

typedef struct{
Conectado conectados[100];
int num;
}ListaConectados;

ListaConectados milista;

int PonerConectados(ListaConectados *milista,char nombre[30],int ID) // Pone en conectados a un nuevo usuario, retorna un 0 si lo consigue o un -1 si no es capaz porque no tiene hueco
{ 
	int correccionID = ID -1;
	if (milista->num==100)
		return -1;
	else{
		pthread_mutex_lock( &mutex);
		strcpy(milista->conectados[milista->num].nombre,nombre);
		milista->conectados[milista->num].ID=ID;
		milista->num=milista->num + 1;
		pthread_mutex_unlock( &mutex);
		return 0;
	}
}

void QuitarConectados(ListaConectados *milista,int ID) // Quita a un usuario de la lista de conectados
{
	int i;
	for(i = 0; i < milista->num; i++)
	{
		if(milista->conectados[i].ID==ID) {
			printf("Esto lo hace");
			for(int j = i; j < milista->num - 1; j++)
				milista->conectados[j] = milista->conectados[j + 1];
			milista->num=milista->num - 1;
		}
	}
	
}

void VerConectado(ListaConectados *milista, char conectados[512]) // Esta funciÛn nos permite ver cuantos usuarios hay conectados
{
	int i;
	strcpy(conectados,"7/");
	for(i =0;i<milista->num;i++)
	{
		sprintf(conectados,"%s%s\n",conectados,milista->conectados[i].nombre);
	}
	printf("%s\n",conectados);
}

void Desconexion(char consulta [400], char nombre [20]) // Esta funcion sirve para crear la desconexion de un usuario 
{

			p= strtok(NULL,"/");
			char contrasenya[20];
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
			IDjug = atoi(row[0]);
			printf("El ID del jugador es: %d\n", IDjug);
			QuitarConectados(&milista, IDjug);	
}

void Login (char consulta[400], char nombre[20], char respuesta [512]) // Esta funcion sirve para logear a un usuario, si no es correcto el nombre o contraseÒa muestra un mensaje aclarandolo, lo mismo para si es correcto
{
			p= strtok(NULL,"/");
			char contrasenya[20];
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
				sprintf (respuesta, "5/No existe el usuario y/o la contrasenya es incorrecta\n");
			else {
				IDjug = atoi(row[0]);
				printf("El ID del jugador es: %d\n", IDjug);
				PonerConectados(&milista, nombre, IDjug);
				sprintf(respuesta, "5/Login exitoso\n");
}

void RegistroUsuario (char nombre[20], char respuesta [512]) //Esta funcion registra a un nuevo usuario en el sistema. Si hay alguien con el mismo nombre te avisa y tambien si el registro ha sido exitoso o ha habido algun problema 
{
			p = strtok(NULL,"/");
			char contrasenya[20];
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
						PonerConectados(&milista, nombre, IDjug);
						sprintf(respuesta, "6/Has sido registrado exitosamente\n");
					}
				}
			}
			
}

void PartidasGanadasPorUsuario(char nombre[20], char respuesta[512]) //Consulta en la base de datos las partidas ganadas por un usuario, escribe el numero de partidas ganadas o un mensaje de error
{
			int num = 0;
			char consulta [200];
			int err;
			MYSQL_ROW row;
			MYSQL_RES *resultado;
			
			
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

void EscenariosJuntos(char nombre[20], char respuesta[512]) // Consulta en la base de datos los escenarios que dos ususarios han jugado juntos y los escribe en pantalla
{
			consulta[200];
			int err;
			MYSQL_ROW row;
			MYSQL_RES *resultado;
			
			
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

void EscenarioMasPuntuado (char nombre[20], char respuesta[512]) //Consulta en la base de datos el escenario con mayor puntuacion de un usuario y lo escribe en pantalla
{
			char consulta[200];
			int err;
			MYSQL_ROW row;
			MYSQL_RES *resultado;
			
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

void PosicionesTablero(char nombre[20], char respuesta[512]) //Consulta en la base de datos la posicion de una persona en el tablero y lo escribe en pantalla
{
			char consulta[200];
			int err;
			MYSQL_ROW row;
			MYSQL_RES *resultado;
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
	int res;
	
	int terminar =0;
	/* Fin del bloque de inicializacion del socket*/
	/*Inicializacion del bloque de consulta SQL*/
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char nombre[20];
	char consulta [400];
	
	conn = mysql_init(NULL); //Creamos una conexion al servidor MYSQL
	if (conn==NULL) {
		printf("Error al crear la conexion 1 %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//else printf("se ha inicializado la conexi√≥n 1\n");
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "basedatos",0, NULL, 0);
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
		
		//if ((codigo !=0)) {
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
		//}
		
		//funcion de desconexiÛn
		if (codigo == 0)
		{
			char conectados[512];
			pthread_mutex_lock(&mutex);
			Desconexion(nombre);
			pthread_mutex_unlock(&mutex);
			sprintf(respuesta, "0/Desconectado");
			printf("%s\n", respuesta);
			write(sock_conn,respuesta,strlen(respuesta));
			terminar = 1;
		}
		//funcion de login de un usuario
		if (codigo==5) { 
			printf("%s\n",nombre);
			printf("%s\n",contrasena);
			
			pthread_mutex_lock(&mutex);
			Login(nombre, contrasena);
			pthread_mutex_unlock(&mutex);
			
			printf("Respuesta: %s\n", respuesta);
			write(sock_conn,respuesta,strlen(respuesta));
			terminar = 1;
			
		}
		//funcion de registro del usuario
		if(codigo==6) { 
			printf("%s\n",nombre);
			printf("%s\n",contrasena);
			
			pthread_mutex_lock(&mutex);
			RegistroUsuario(nombre, contrasena);
			pthread_mutex_unlock(&mutex);
			
			printf("Respuesta: %s\n", respuesta);
			write(sock_conn,respuesta,strlen(respuesta));
			terminar = 1;
				
				
		}
		//Consulta para  saber la cantidad de partidas que ha ganado una persona
		if (codigo==1) { 
			pthread_mutex_lock(&mutex);
			int res = PartidasGanadasPorUsuario(respuesta, nombre);
			pthread_mutex_unlock(&mutex);
			
			printf("Respuesta: %s\n", respuesta);
			write(sock_conn,respuesta,strlen(respuesta));
			
		}
		//Consulta para saber en qu√© escenarios 2 jugadores han jugado juntos
		if (codigo==2) { 
			pthread_mutex_lock(&mutex);
			EscenariosJuntos(respuesta, nombre, nombre2);
			pthread_mutex_unlock(&mutex);
			
			printf("Respuesta: %s\n", respuesta);
			write(sock_conn,respuesta,strlen(respuesta));
		}
		
		//Consulta para  saber en qu√© escenario he obtenido mas puntos
		if (codigo==3) { 
			
			pthread_mutex_lock(&mutex);
			EscenarioMasPuntuado(respuesta, nombre); 
			pthread_mutex_unlock(&mutex);
			
			printf("Respuesta: %s\n", respuesta);
			write(sock_conn,respuesta,strlen(respuesta));
		}
		
		//Consulta para saber el tablero de posiciones
		if (codigo==4) { 
			
			pthread_mutex_lock(&mutex);
			PosicionesTablero(respuesta, nombre);
			pthread_mutex_unlock(&mutex);
			
			printf("Respuesta: %s\n", respuesta);
			write(sock_conn,respuesta,strlen(respuesta));
		}
		
		if (codigo !=0) {
			printf ("Respuesta: %s\n", respuesta); // Enviamos respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		}
		if ((codigo == 0) || (codigo == 1) || (codigo ==2) || (codigo ==3) || (codigo ==4) || (codigo ==5) || (codigo ==6))
		{
			pthread_mutex_lock( &mutex);
			char conectados[512];
			VerConectado(&milista, conectados);
			pthread_mutex_unlock (&mutex);
			//char notificacion[512];
			//sprintf(notificacion, "7/%d", conectados);
			printf("%s\n",conectados);
			int j;
			for (j=0; j<i;j++)
				write (sockets[j], conectados, strlen(conectados));
			
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
	
	serv_adr.sin_port = htons(9000); // establecemos el puerto de escucha
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
