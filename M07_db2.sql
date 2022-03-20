DROP DATABASE IF EXISTS M07_DB;

CREATE DATABASE M07_DB;

USE M07_DB;

CREATE TABLE JUGADOR(
	ID INTEGER PRIMARY KEY NOT NULL,
	NOMBRE VARCHAR(60),
	CONTRASENYA VARCHAR(20)
)ENGINE=InnoDB;

CREATE TABLE PARTIDA(
	TABLERO VARCHAR(50),
	ID INTEGER PRIMARY KEY NOT NULL,
	GANADOR VARCHAR (60),
	FECHA VARCHAR(50),
	HORA VARCHAR(50),
	DURACION FLOAT
)ENGINE=InnoDB;


CREATE TABLE RESULTADOS(
	ID_J INTEGER NOT NULL,
	ID_P INTEGER NOT NULL,
	PUNTOS INTEGER,
	FOREIGN KEY (ID_J) REFERENCES JUGADOR(ID),
	FOREIGN KEY (ID_P) REFERENCES PARTIDA(ID)
)ENGINE=InnoDB;


INSERT INTO JUGADOR VALUES (1,'DAVID','UNO');
INSERT INTO JUGADOR VALUES (2,'JUAN','DOS');
INSERT INTO JUGADOR VALUES (3,'GERARD','TRES');
INSERT INTO JUGADOR VALUES (4,'MIGUEL','QUATRO');

INSERT INTO PARTIDA VALUES ('Madrid',1,'Juan','12/03/2022','15:00',65.32);
INSERT INTO PARTIDA VALUES ('Barcelona',2,'David','22/12/2023','17:00',79.32);


INSERT INTO RESULTADOS VALUES(1,1,25);
INSERT INTO RESULTADOS VALUES(2,1,35);


