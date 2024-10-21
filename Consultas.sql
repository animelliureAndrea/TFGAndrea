use tfgCinPadd
SELECT c.nombre, c.descripcion, c.ubicación, c.fecha, c.codPelicula, u.nombre AS nombreDirector, u.apellido1
FROM dbo.castings c 
INNER JOIN dbo.usuarios u ON c.director = u.codDirector 
WHERE c.codCasting = 10;

SELECT p.titulo
FROM peliculas p
WHERE p.codPeli = (SELECT c.codPelicula FROM castings c WHERE c.codCasting = 14);

use tfgCinPadd
select g.nombre, g.sinopsis, u.nombre, u.apellido1 
from guiones g
INNER JOIN usuarios u ON g.guionista = u.codGuionista
where g.codGuion = 1;

use tfgCinPadd
select cs.nombre, cs.interesados, u.nombre, u.apellido1
from castingSeleccionado cs
inner join usuarios u on cs.codActor = u.codActor
where cs.director = 6;

SELECT codDirector FROM usuarios WHERE cod =8;

use tfgCinPadd
SELECT TOP 1 codCasting FROM castingSeleccionado 
                              WHERE director = 6 AND codCasting > 13
                              ORDER BY codCasting ASC;
use tfgCinPadd
UPDATE castings
SET interesados = 2
WHERE codCasting = 10;

use tfgCinPadd
SELECT a.temasInteres FROM aficionado a WHERE a.codAficionado = (SELECT u.codAficionado FROM usuarios u WHERE u.cod = 1)

use tfgCinPadd
select p.titulo, p.descripcion, p.genero, u.nombre As director, u.apellido1 As directorApe, us.nombre As Guionista, us.apellido1 As GuionApe, p.nºActores, p.año
from peliculas p 
inner join usuarios u on p.director = u.codDirector
inner join usuarios us on p.guionista = us.codGuionista
where p.codPeli = 10;

use tfgCinPadd
select a.instagram, a.habilidad1, a.habilidad2, u.nombre, u.apellido1
from actor a 
inner join usuarios u on a.codActor = u.codActor
where a.codActor = 3;

use tfgCinPadd
select a.etnia, a.ojos, a.colorPelo, a.largoPelo, a.tinte, a.tipoPelo, a.tatoo, a.piercing, a.altura, a.medidas
from apariencia a
where a.codActor = 3;

use tfgCinPadd
select u.tipo
from usuarios u
where u.cod = 7;

select u.nombreUser, u.contraseña, u.correo, u.nombre, u.apellido1, u.apellido2, u.nacionalidad, u.tipo, u.nacimiento
from usuarios u
where u.cod = 7;

select a.directorFav, a.generoFav, a.temasInteres
from aficionado a
where a.codAficionado = 1;

select u.codAficionado
from usuarios u
where u.cod = 1;

use tfgCinPadd
select * from castingSeleccionado where codActor = 3;

select u.nombre, u.apellido1
from usuarios u 
where u.codDirector = 1;

select f.nombre, f.fecha, f.ubicacion, f.NºPeliculasPresentadas
from festivales f
where f.codFestival = 1;

use tfgCinPadd
select p.titulo, p.codPeli
from peliculas p

SELECT p.codPeli FROM peliculas p WHERE p.titulo = 'El secreto de la montaña';
 
SELECT c.cod, c.puntuacion, c.comentario, u.nombre  
                                   FROM criticas c  
                                   JOIN usuarios u ON c.codUsuario = u.cod  
                                   WHERE c.codPelicula = 10
select * from criticas where codUsuario = 1

select * from guiones g where g.guionista = 4;

select u.codGuionista from usuarios u where u.cod = 23

select * from planes p where p.idDirector = 23;

select u.nombre, u.apellido1 from usuarios u where u.tipo = 'Director';

use tfgCinPadd
select g.nombre from guiones g;

select u.nombre, u.apellido1 from usuarios u where u.tipo = 'Guionista';

select * from peliculas;

 use tfgCinPadd
 SELECT COUNT(*) FROM castingSeleccionado WHERE codActor = 3 AND nombre = 'Casting figurantes';

 use tfgCinPadd
 select MAX(codCasting) from castings;

 select MIN(codCasting) from castings