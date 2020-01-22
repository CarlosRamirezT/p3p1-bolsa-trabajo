create database p3p1BolsaTrabajo
go
use p3p1BolsaTrabajo
go
create table Usuarios(
	id_usuarios int identity(1,1) not null primary key,
	email varchar(45) not null,
	password_usuario varchar(45) not null,
	rol varchar(30) not null
)
go
	create unique index idx_email on Usuarios(email)
go
create table categoriaOfertaEmpleos(
	id_categoria_ofertas int identity(1,1) not null primary key,
	titulo varchar(45) not null
)
go
create table Ofertas(
	id_ofertas int identity(1,1) not null primary key,
	titulo varchar(45) not null,
	descripcion varchar(45) not null,
	fecha_posteo datetime not null,
	activo bit not null,
	id_categoria_ofertas int not null,
	ubicacion varchar(45) not null,
	posicion varchar(45) not null,
	nombre_empresa varchar(45) not null
)
go
	alter table Ofertas add constraint fk_id_categoria_ofertas foreign key (id_categoria_ofertas) references categoriaOfertaEmpleos (id_categoria_ofertas)
go
	alter table Ofertas add constraint ck_estado check (estado in ('activa', 'inactiva'))
go
create table Configuraciones(
	id_configuraciones int identity(1,1) not null primary key,
	nombre varchar(45) not null,
	valor_configuracion int not null
)
go

