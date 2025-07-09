create database MetodoLeer
go
use MetodoLeer;
go

create table Peliculas(
id int primary key identity (1,1),
nombre varchar(50) not null,
director varchar(50) not null,
fechaLanzamiento date
);

insert into Peliculas(nombre, director, fechaLanzamiento) values 
('The Shawshank Redemption', 'Frank Darabont', '1994/09/23'),
('The Godfather', 'Francis Ford Coppola', '1972/03/24'),
('Pulp Fiction', 'Quentin Tarantino', '1994/10/14'),
('The Dark Knight', 'Christopher Nolan', '2008/07/18'),
('Fight Club', 'David Fincher', '1999/10/15')
;

select * from Peliculas
