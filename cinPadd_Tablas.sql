drop database if exists tfgCinPadd;
CREATE database tfgCinPadd;

use tfgCinPadd;
DROP TABLE if exists director;
CREATE TABLE director(
	codDirector int primary key IDENTITY,
	instagram varchar(30),
	enlacePortfolio varchar(100),
	telefono varchar(9) not null,
	equipoFijo bit not null,
	experiencia bit not null,
	idiomaNacimiento varchar(30) not null,
	numIdiomas int,
	portfolio bit not null
);

DROP TABLE if exists actor;
CREATE TABLE actor(
	codActor int primary key IDENTITY,
	representante bit not null,
	estudios bit not null,
	instagram varchar(100),
	idiomaNacimiento varchar(30) not null,
	numIdiomas int,
	telefono varchar(100) not null,
	habilidad1 VARCHAR(50) CHECK (habilidad1 IN ('baile', 'canto', 'instrumento', 'circo', 'deporte', 'conducción')),
    habilidad2 VARCHAR(50) CHECK (habilidad2 IN ('baile', 'canto', 'instrumento', 'circo', 'deporte', 'conducción')),
	experiencia bit not null,
	book bit not null,
	videoBook bit not null
);

DROP TABLE if exists apariencia;
CREATE TABLE apariencia(
	codActor int Primary key,
	ojos VARCHAR(30) not null,
	etnia VARCHAR(30) not null,
	colorPelo VARCHAR(30) not null,
	largoPelo VARCHAR(30) CHECK (largoPelo IN ('largo', 'medio', 'corto')) NOT NULL,
    tipoPelo VARCHAR(30) CHECK (tipoPelo IN ('liso', 'ondas', 'rizo', 'afro')) NOT NULL,
	tinte bit not null,
	tatoo bit not null,
	piercing bit not null,
	altura VARCHAR(30) not null,
	medidas VARCHAR(30) not null,
	FOREIGN KEY (codActor) REFERENCES actor(codActor)
);

DROP TABLE if exists guionista;
CREATE TABLE guionista(
	codGuionista int primary key IDENTITY,
	tipoEscritor VARCHAR(30) CHECK (tipoEscritor IN ('esquemático', 'lineal')) NOT NULL,
	generoPreferido VARCHAR(30),
	instagram varchar(100),
	telefono varchar(100) not null,
	experiencia bit not null,
	idiomaNacimiento varchar(30) not null,
	numIdiomas int
);

DROP TABLE if exists aficionado;
CREATE TABLE aficionado(
	codAficionado int primary key IDENTITY,
	generoFav varchar(30),
	directorFav varchar(30),
	temasInteres VARCHAR(100) CHECK (temasInteres IN ('películas', 'actores', 'estrenos', 'guiones'))
);

use tfgCinPadd;
DROP TABLE if exists usuarios;
CREATE TABLE usuarios(
	cod INT PRIMARY KEY IDENTITY,
	nombreUser VARCHAR(30) not null,
	contraseña VARCHAR(30) not null,
	correo VARCHAR(30) not null,
	nombre VARCHAR(30) not null,
	apellido1 VARCHAR(30) not null,
	apellido2 VARCHAR(30),
	nacimiento DATE not null,
	nacionalidad VARCHAR(20) not null,
	codDirector int,
	codActor int,
	codGuionista int,
	codAficionado int,
	tipo VARCHAR(20) CHECK (tipo IN ('director', 'actor', 'guionista', 'aficionado')) NOT NULL,
	FOREIGN KEY (codDirector) REFERENCES director(codDirector),
	FOREIGN KEY (codActor) REFERENCES actor(codActor),
	FOREIGN KEY (codGuionista) REFERENCES guionista(codGuionista),
	FOREIGN KEY (codAficionado) REFERENCES aficionado(codAficionado)
);

use tfgCinPadd;
DROP TABLE if exists guiones;
CREATE TABLE guiones(
	codGuion int primary key IDENTITY,
	nombre varchar(30) not null,
	guionista int not null,
	genero varchar(30) not null,
	año date not null,
	sinopsis varchar(300) not null,
	FOREIGN KEY (guionista) REFERENCES guionista(codGuionista)
);

DROP TABLE if exists peliculas;
CREATE TABLE peliculas(
	codPeli int primary key IDENTITY,
	titulo varchar(30) not null,
	descripcion varchar(100) not null,
	nºActores int not null,
	director int not null,
	guionista int not null,
	guion int not null,
	genero varchar(30) not null,
	año date not null,
	FOREIGN KEY (director) REFERENCES director(codDirector),
	FOREIGN KEY (guionista) REFERENCES guionista(codGuionista),
	FOREIGN KEY (guion) REFERENCES guiones(codGuion)
);

DROP TABLE if exists castings;
CREATE TABLE castings(
	codCasting int primary key IDENTITY,
	nombre varchar(30) not null,
	descripcion varchar(100) not null,
	director int,
	ubicación varchar(50) not null,
	interesados int not null,
	fecha date not null,
	codPelicula int,
	FOREIGN KEY (codPelicula) REFERENCES peliculas(codPeli),
	FOREIGN KEY (director) REFERENCES director(codDirector)
);

DROP TABLE if exists castingSeleccionado;
CREATE TABLE castingSeleccionado(
	codCasting int primary key IDENTITY,
	codActor int,
	nombre varchar(30) not null,
	descripcion varchar(100) not null,
	director int,
	ubicacion varchar(50) not null,
	interesados int not null,
	fecha date not null,
	codPelicula int,
	Foreign key (codActor) References actor(codActor),
	FOREIGN KEY (codPelicula) REFERENCES peliculas(codPeli),
	FOREIGN KEY (director) REFERENCES director(codDirector)
);

DROP TABLE if exists festivales;
CREATE TABLE festivales(
	codFestival int primary key IDENTITY,
	nombre VARCHAR(30) not null,
	fecha DATE not null,
	ubicacion varchar(50) not null,
	NºPeliculasPresentadas int not null
);

DROP TABLE if exists criticas;
CREATE TABLE criticas(
	cod int primary key IDENTITY,
	codPelicula int,
	codUsuario int,
	puntuacion INT CHECK (puntuacion IN (1,2,3,4,5)) NOT NULL,
	comentario varchar(200) not null,
	FOREIGN KEY (codPelicula) REFERENCES peliculas(codPeli),
	FOREIGN KEY (codUsuario) REFERENCES usuarios(cod)
);

Drop table if exists planes;
create table planes(
	idPlan int primary key identity,
	idDirector int,
	fecha date not null,
	actividad VARCHAR(30) CHECK (actividad IN ('grabacion', 'casting', 'edicion', 'presentacion', 'publicidad', 'decorados')) NOT NULL,
    horarios VARCHAR(30) NOT NULL,
    llamadas VARCHAR(30) NOT NULL,
    problemas VARCHAR(30),
    estado VARCHAR(30) CHECK (estado IN ('Progreso', 'SinEmpezar')) NOT NULL,
	FOREIGN KEY (idDirector) REFERENCES director(codDirector)
);

Drop table if exists productora;
create table productora(
	idProductora int primary key identity,
	nombre varchar(30) not null,
	direccion varchar(30) not null,
	telefono varchar(30) not null,
	mail varchar(30) not null
);

Drop table if exists escenario;
create table escenario(
	idLugar int primary key identity,
	nombre varchar(30) not null,
	direccion varchar(30) not null,
	telefono varchar(30) not null,
	capacidadMax int not null
);


