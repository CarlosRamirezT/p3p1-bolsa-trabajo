use p3p1BolsaTrabajo

select * from categoriaOfertaEmpleos
insert into categoriaOfertaEmpleos values(
'Software'
)
insert into categoriaOfertaEmpleos values(
'Limpieza'
)
insert into categoriaOfertaEmpleos values(
'Lolsito'
)

select * from Ofertas
truncate table Ofertas

insert into Ofertas values(
'Se busca Programador',
'Description Programador Senior',
GETDATE(),
1,
1,
'Santo Domingo',
'Senior Developer',
'Cadara Software'
)

insert into Ofertas values(
'Se busca Desarrollador',
'Description Desarrollador Junior',
GETDATE(),
0,
1,
'Santiago',
'Intermediate Developer',
'Cadara Software'
)

insert into Ofertas values(
'Jugador De Quidish',
'Description Programador Senior',
GETDATE(),
1,
1,
'San Juan',
'Delantero',
'hogwarts'
)

insert into Ofertas values(
'Analista Software',
'Description Programador Senior',
GETDATE(),
0,
1,
'Santo Domingo',
'Senior Analist',
'Cindy Software'
)

insert into Ofertas values(
'Analista Desarrollo',
'Description Desarrollador Senior',
GETDATE(),
1,
1,
'Santo Domingo',
'Senior Development Analist',
'Cindy Software'
)

insert into Ofertas values(
'Jugaodor Lol',
'Description Juggador Senior',
GETDATE(),
1,
2,
'Santo Domingo',
'Senior Jugaor',
'Cindy Software'
)

insert into Ofertas values(
'Lavador de Carro',
'Description lavador Senior',
GETDATE(),
1,
3,
'Santo Domingo',
'Senior Lavador',
'Cindy Software'
)

select * from ofertas where activo = 1 order by id_categoria_ofertas