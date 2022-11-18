create database hotel;
go

use hotel;
go

create table usuarios (
	usuario varchar(50) not null primary key,
	contrasena varchar(50) not null,
    usuario_activo bit not null
)

create table roles (
	id_rol numeric identity(1,1) not null primary key,
	descripcion varchar(255) not null,
	rol_activo bit not null
)

create table roles_usuarios (
	id numeric identity(1,1) not null primary key,
	usuario varchar(50) not null,
	id_rol numeric not null
)

create table clientes (
    id_cliente numeric not null primary key,
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

create table tipos_habitaciones (
    id_tipo_habitacion numeric identity(1,1) not null primary key,
    descripcion varchar(255) not null,
    precio_noche numeric not null);

create table habitaciones (
	id_habitacion numeric not null primary key,
    num_habitacion numeric not null,
    piso_habitacion numeric not null,
    id_tipo_habitacion numeric not null,
    capacidad_personas numeric not null,
    habitacion_activa bit not null
)

create table reservaciones (
    id_reservacion numeric identity(1,1) not null primary key,
    id_cliente numeric not null,
	id_habitacion numeric,
    cantidad_acompanantes numeric not null,
    fecha_entrada datetime not null,
    fecha_salida datetime not null,
    estado_reservacion varchar(1) not null,
    costo_reservacion numeric not null,
    costo_reservacion_pagado bit not null,
)

alter table roles_usuarios
	with check 
	add constraint fk_roles_usuarios_roles
	foreign key (id_rol) 
	references roles (id_rol)
go

alter table roles_usuarios
	check constraint fk_roles_usuarios_roles
go

alter table roles_usuarios
	with check 
	add constraint fk_roles_usuarios_usuarios
	foreign key (usuario) 
	references usuarios (usuario)
go

alter table roles_usuarios
	check constraint fk_roles_usuarios_usuarios
go

alter table habitaciones
	with check 
	add constraint fk_habitaciones_tipos_habitaciones
	foreign key (id_tipo_habitacion) 
	references tipos_habitaciones (id_tipo_habitacion)
go

alter table habitaciones
	check constraint fk_habitaciones_tipos_habitaciones
go

alter table reservaciones
	with check 
	add constraint fk_reservaciones_clientes
	foreign key (id_cliente) 
	references clientes (id_cliente)
go

alter table reservaciones
	check constraint fk_reservaciones_clientes
go

alter table reservaciones
	with check 
	add constraint fk_reservaciones_habitaciones
	foreign key (id_habitacion) 
	references habitaciones (id_habitacion)
go

alter table reservaciones
	check constraint fk_reservaciones_habitaciones
go

insert into usuarios (
    usuario,
    contrasena,
    usuario_activo
)
values (
    'admin',
    'admin',
    1
)

insert into roles (
    descripcion,
    rol_activo
)
values (
    'Gerente',
    1
)

insert into roles_usuarios (
    usuario,
    id_rol
) values (
    'admin',
    1
)

insert into tipos_habitaciones (
	descripcion,
	precio_noche
) values (
	'Prueba',
	123.45
)

insert into habitaciones (
	id_habitacion,
	num_habitacion,
	piso_habitacion,
	id_tipo_habitacion,
	capacidad_personas,
	habitacion_activa
) values (
	1001,
	1,
	1,
	1,
	500,
	1
)
go

// /*
create view hotel.habitaciones_disponibles as 
	select
		h.*
	from hotel.reservaciones r right outer join hotel.habitaciones h
		on r.num_habitacion = h.num_habitacion
	where
		r.id_reservacion is null; 
// */