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
16,
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


/*test for presentation*/
delete from categoriaOfertaEmpleos
select * from categoriaOfertaEmpleos
insert into categoriaOfertaEmpleos values(
'Software'
)
insert into categoriaOfertaEmpleos values(
'Limpieza'
)
insert into categoriaOfertaEmpleos values(
'Educación'
)
insert into categoriaOfertaEmpleos values(
'Administración'
)

truncate table Ofertas
select * from Ofertas
insert into Ofertas values(
'Se busca Programador',
'Description Programador Senior',
GETDATE(),
1,
16,
'Santo Domingo',
'Senior Developer',
'Cadara Software'
)
insert into Ofertas values(
'Se busca Analista de Software',
'Ingenieria o carreras afines',
GETDATE(),
1,
16,
'La Vega',
'Software Analist',
'Cadara Software'
)
insert into Ofertas values(
'Se busca programador frontend',
'Manejo C# y tecnologias afines',
GETDATE(),
1,
16,
'Santo Domingo',
'Senior Backend Developer',
'Cadara Software'
)
insert into Ofertas values(
'Se busca programador backend',
'Manejo C# y tecnologias afines',
GETDATE(),
1,
16,
'Santo Domingo',
'Senior Backend Developer',
'Cadara Software'
)
insert into Ofertas values(
'Se busca ingeniero devop',
'Manejo docker y tecnologias afines',
GETDATE(),
1,
16,
'Santo Domingo',
'Senior DevOp Engineer',
'Cadara Software'
)
insert into Ofertas values(
'Se busca administrador de base de datos',
'Manejo de sql server y afines',
GETDATE(),
1,
16,
'Santo Domingo',
'Senior Database Administrator',
'Cadara Software'
)
insert into Ofertas values(
'Se busca trabajadora domestica',
'Mujer mayor de 20 años',
GETDATE(),
1,
17,
'Santiago',
'Encargada de limpieza',
'Regus'
)
insert into Ofertas values(
'Se busca trabajadora domestica',
'Mujer mayor de 25 años',
GETDATE(),
1,
17,
'Santiago',
'Encargada de limpieza',
'Roble Corporate Center'
)
insert into Ofertas values(
'Se busca profesora',
'Licencida en educacion',
GETDATE(),
1,
18,
'Santiago',
'Profesora de Ciencias Naturales',
'Colegio Nuevo Renacer'
)
insert into Ofertas values(
'Se busca Psicoloda',
'Licenciada en Psicologia Clinica o Afines',
GETDATE(),
1,
18,
'Moca',
'Orientadora',
'Colegio Nuevo Renacer'
)
insert into Ofertas values(
'Se busca contador',
'Licenciado en Contabilidad o Carreras Afines',
GETDATE(),
1,
19,
'La Vega',
'Contable',
'Rubier Corporate Center'
)
insert into Ofertas values(
'Se busca administrador',
'Licenciado en Administracion o Carreras Afines',
GETDATE(),
1,
19,
'La Vega',
'Administrador de Almacer',
'Rubier Corporate Center'
)