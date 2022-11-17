use progravan
go

create schema hotel;
go

create table hotel.usuarios (
	usuario varchar(50) not null primary key,
	contrasena varchar(50) not null,
    usuario_activo bit not null
)

create table hotel.roles (
	id_rol numeric identity(1,1) not null primary key,
	descripcion varchar(255) not null,
	rol_activo bit not null
)

create table hotel.roles_usuarios (
	id numeric identity(1,1) not null primary key,
	usuario varchar(50) not null,
	rol numeric not null
)

create table hotel.tipos_habitaciones (
    id_tipo_habitacion numeric identity(1,1) not null primary key,
    descripcion varchar(255) not null,
    precio_noche numeric not null);

create table hotel.habitaciones (
    num_habitacion numeric not null primary key,
    piso_habitacion numeric not null,
    tipo_habitacion numeric not null,
    capacidad_personas numeric not null,
    habitacion_activa bit not null
)

create table hotel.clientes (
    id_cliente numeric not null primary key,
	usuario varchar(50),
    nombre_completo varchar(100) not null,
    correo_electronico varchar(100) not null,
    telefono_contacto varchar(50) not null,
    cliente_activo bit not null,
    pais varchar(100) not null,
    estado varchar(100) not null,
    municipalidad varchar(100) not null,
    localidad varchar(100) not null,
    codigo_postal varchar(10) not null,
    direccion varchar(255)
)

create table hotel.reservaciones (
    id_reservacion numeric identity(1,1) not null primary key,
    cliente numeric not null,
	num_habitacion numeric,
    cantidad_acompanantes numeric not null,
    fecha_entrada datetime not null,
    fecha_salida datetime not null,
    estado_reservacion varchar(1) not null,
    costo_reservacion numeric not null,
    costo_reservacion_pagado bit not null,
)

create table hotel.acompanantes_reservaciones (
    id_invitados_reservacion numeric identity(1,1) not null primary key,
    id_reservacion numeric not null,
    nombre_completo_invitado varchar(100) not null,
    edad_invitado numeric not null,
    tipo_invitado varchar(1) not null
)

insert into hotel.usuarios (
    usuario,
    contrasena,
    usuario_activo
)
values (
    'admin',
    'admin',
    1
)

insert into hotel.roles (
    descripcion,
    rol_activo
)
values (
    'Gerente',
    1
)

insert into hotel.roles_usuarios (
    usuario,
    rol
) values (
    'admin',
    1
)

insert into hotel.tipos_habitaciones (
	descripcion,
	precio_noche
) values (
	'Prueba',
	123.45
)

insert into hotel.habitaciones (
	num_habitacion,
	piso_habitacion,
	tipo_habitacion,
	capacidad_personas,
	habitacion_activa
) values (
	001,
	1,
	1,
	500,
	1
)

go

create view hotel.habitaciones_disponibles as 
	select
		h.*
	from hotel.reservaciones r right outer join hotel.habitaciones h
		on r.num_habitacion = h.num_habitacion
	where
		r.id_reservacion is null;
