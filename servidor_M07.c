/*Servidor del proyecto del grupo 7
Versión: 1
Fecha: 29/03/2022
Asignatura: Sistemes Operatius
Profesor: M. Valero
Autores: M. Jawhari, G. Leon, J. Martinez, D. Mur.
Universitat Politecnica de Catalunya
*/
#include <stdio.h>
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include<mysql.h>

int main(int argc, char *argv[])
{
	/* Inicializacin del socket del servidor.
	Este bloque servirá para crear el socket que comunicará al
	servidor con los múltiples clientes*/
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
	char peticion[512];  //inicialización de variables de petición-respuesta
	char respuesta[512];
	/* Fin del bloque de inicialización del socket*/
	
	/*Inicializacion del bloque de consulta SQL*/
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char nombre[20];
	char consulta [300];
	
	conn = mysql_init(NULL); //Creamos una conexion al servidor MYSQL
	if (conn==NULL) {
		printf("Error al crear la conexión 1 %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//else printf("se ha inicializado la conexión 1\n");
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "basedatos",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexi??n 2: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	/*Fin del bloque de inicialización de SQL*/
	
	/* consulta SQL para obtener una tabla con todos los datos
	de la base de datos*/
	/*err=mysql_query (conn, "SELECT * FROM jugador");
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}*/
	
	/*Bucle de escucha a clientes*/
	for (;;) {
		printf ("Escuchando\n");
	
		sock_conn = accept(sock_listen, NULL, NULL); //sock_conn es el socket que usaremos para este cliente
		printf ("He recibido conexion\n");
	
		int terminar =0;
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
			if (codigo !=0) {
				p = strtok( NULL, "/");
				strcpy (nombre, p);
				printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
			}
			if (codigo ==0) //peticion de desconexi?n
				terminar=1;
		
			if (codigo==5) { //funcion de login de un usuario
				p= strtok(NULL,"/");
				char contrasenya[20];
				strcpy (contrasenya, p);
				sprintf(respuesta,"SELECT jugador.NOMBRE AND jugador.CONTRASENYA FROM (jugador)) WHERE jugador.NOMBRE ='%s' AND jugador.CONTRASENYA ='%s'",nombre,contrasenya);
			}
			
			if(codigo==6) {
				p = strtok(NULL,"/");
				char contrasenya[20];
				strcpy (contrasenya, p);
				printf("Contraseña: %s\n",contrasenya);
				//Registro(respuesta, nombre, contrasenya);
				int err=0;
				char con[300];
				sprintf(con, "SELECT COUNT(ID) FROM jugador WHERE ID IS NOT NULL;");
				printf("Consulta: %s\n",con);
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
					printf("Resultado del count: %d\n",num);
					sprintf(con,"INSERT INTO jugador VALUES(%d,'%s','%s');", num, nombre, contrasenya);
					printf("Consulta: %s\n",con);
					err = mysql_query(conn,con);
					//err = mysql_query(conn, con);
					if (err!=0)
					{
						printf ("Error al registrar el jugador %u %s\n",
								mysql_errno(conn), mysql_error(conn));
						exit (1);
					}
					else
					sprintf(respuesta, "Has sido registrado exitosamente\n");
				}
			}
			if (codigo==1) {
				sprintf(respuesta,"SELECT COUNT PARTIDA.ID_G FROM (RESUTADOS,PARTIDA,JUGADOR) WHERE PERONA.NOMBRE = '%s' AND PERSONA.ID=RESULTADOS.ID_J AND RESULTADOS.ID_P=PARTIDA.ID_P",nombre);
				err=mysql_query (conn, consulta); 
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
					mysql_errno(conn), mysql_error(conn));
				}
			}
			if (codigo !=0) {
				printf ("Respuesta: %s\n", respuesta); // Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
			}
		}
		// Se acabo el servicio para este cliente
		close(sock_conn);
		mysql_close (conn);
		exit(0);
	}
	
}
/*
int Registro(char respuesta[550],char nombre[30],char contrasenya[30]) {
	int err;
	char con[300];
	strcpy(con ,"INSERT INTO JUGADOR VALUES(");
	strcat (con, "0, nombre, contrasenya);");
	strcat (con, ",'");
	strcat (con, nombre);
	strcat (con, "','");
	strcat (con, contrasenya);
	strcat (con,"',");
	strcat (con, "0");
	strcat (con, ",");
	strcat (con, "0");
	strcat (con, ");");

	err=mysql_query (conn,con); 
	if (err!=0) {
		printf ("Error al introducir datos de la base %u %s\n", 7)
		mysql_errno(conn), mysql_error(conn));
		exit (1);
		return -1;
	}
	else {
	printf(respuesta,"Te has registrado correctamente\n");
	return 0;
	}
}
*/
