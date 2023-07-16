
CREATE DATABASE cine;
GO

USE cine;
GO

CREATE TABLE usuarios(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	nombre VARCHAR(40) NOT NULL,
	usuario VARCHAR(40) NOT NULL,
	pass VARCHAR(40) NOT NULL,
	correo VARCHAR(50) NOT NULL
);

CREATE TABLE clasificaciones(
	nombre VARCHAR(30) NOT NULL PRIMARY KEY
);

INSERT INTO clasificaciones(nombre) VALUES ('TP'), ('+3'), ('+12'), ('+15'), ('+18');

CREATE TABLE peliculas(
	codigo VARCHAR(30) NOT NULL PRIMARY KEY,
	nombre VARCHAR(30) NOT NULL,
	clasificacion VARCHAR(30) NOT NULL
);
ALTER TABLE peliculas ADD CONSTRAINT fk_clasificacion FOREIGN KEY (clasificacion) REFERENCES clasificaciones(nombre)
ON UPDATE CASCADE ON DELETE NO ACTION;

CREATE TABLE salas(
	codigo VARCHAR(30) NOT NULL PRIMARY KEY,
	capacidad INT NOT NULL
);

CREATE TABLE funciones(
	codigo VARCHAR(30) NOT NULL PRIMARY KEY,
	fecha VARCHAR(30) NOT NULL,
	codigoPelicula VARCHAR(30) NOT NULL,
	codigoSala VARCHAR(30) NOT NULL
);
ALTER TABLE funciones ADD CONSTRAINT fk_codigoPelicula FOREIGN KEY (codigoPelicula) REFERENCES peliculas(codigo)
ON UPDATE CASCADE ON DELETE CASCADE;
ALTER TABLE funciones ADD CONSTRAINT fk_codigoSala FOREIGN KEY (codigoSala) REFERENCES salas(codigo)
ON UPDATE CASCADE ON DELETE CASCADE;

INSERT INTO usuarios(nombre,usuario,pass,correo) VALUES ('Admin Principal', 'admin', '1234', 'admin@cine.com');

INSERT INTO salas(codigo,capacidad) VALUES ('1',100);

INSERT INTO peliculas(codigo,nombre,clasificacion) VALUES ('4', 'Rápidos y furiosos', '+15');

INSERT INTO funciones(codigo,fecha,codigoPelicula,codigoSala) VALUES ('1','28/06/2023','1','1');