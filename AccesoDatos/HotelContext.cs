using System;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AccesoDatos
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Habitaciones> Habitaciones { get; set; }
        public virtual DbSet<Reservaciones> Reservaciones { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesUsuarios> RolesUsuarios { get; set; }
        public virtual DbSet<TiposHabitaciones> TiposHabitaciones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=hotel;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__clientes__677F38F523B20092");

                entity.ToTable("clientes");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ClienteActivo).HasColumnName("cliente_activo");

                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasColumnName("codigo_postal")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasColumnName("correo_electronico")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Localidad)
                    .IsRequired()
                    .HasColumnName("localidad")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Municipalidad)
                    .IsRequired()
                    .HasColumnName("municipalidad")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasColumnName("nombre_completo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasColumnName("pais")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoContacto)
                    .IsRequired()
                    .HasColumnName("telefono_contacto")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Habitaciones>(entity =>
            {
                entity.HasKey(e => e.IdHabitacion)
                    .HasName("PK__habitaci__773F28F34F6B31C0");

                entity.ToTable("habitaciones");

                entity.Property(e => e.IdHabitacion)
                    .HasColumnName("id_habitacion")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CapacidadPersonas)
                    .HasColumnName("capacidad_personas")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.HabitacionActiva).HasColumnName("habitacion_activa");

                entity.Property(e => e.IdTipoHabitacion)
                    .HasColumnName("id_tipo_habitacion")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NumHabitacion)
                    .HasColumnName("num_habitacion")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PisoHabitacion)
                    .HasColumnName("piso_habitacion")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.IdTipoHabitacionNavigation)
                    .WithMany(p => p.Habitaciones)
                    .HasForeignKey(d => d.IdTipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_habitaciones_tipos_habitaciones");
            });

            modelBuilder.Entity<Reservaciones>(entity =>
            {
                entity.HasKey(e => e.IdReservacion)
                    .HasName("PK__reservac__786D5E83ECF3838B");

                entity.ToTable("reservaciones");

                entity.Property(e => e.IdReservacion)
                    .HasColumnName("id_reservacion")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CantidadAcompanantes)
                    .HasColumnName("cantidad_acompanantes")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CostoReservacion)
                    .HasColumnName("costo_reservacion")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CostoReservacionPagado).HasColumnName("costo_reservacion_pagado");

                entity.Property(e => e.EstadoReservacion)
                    .IsRequired()
                    .HasColumnName("estado_reservacion")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEntrada)
                    .HasColumnName("fecha_entrada")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaSalida)
                    .HasColumnName("fecha_salida")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdHabitacion)
                    .HasColumnName("id_habitacion")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reservaciones_clientes");

                entity.HasOne(d => d.IdHabitacionNavigation)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.IdHabitacion)
                    .HasConstraintName("fk_reservaciones_habitaciones");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__roles__6ABCB5E028C9DA41");

                entity.ToTable("roles");

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RolActivo).HasColumnName("rol_activo");
            });

            modelBuilder.Entity<RolesUsuarios>(entity =>
            {
                entity.ToTable("roles_usuarios");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolesUsuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_roles_usuarios_roles");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.RolesUsuarios)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_roles_usuarios_usuarios");
            });

            modelBuilder.Entity<TiposHabitaciones>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabitacion)
                    .HasName("PK__tipos_ha__6A65108C8299B2B2");

                entity.ToTable("tipos_habitaciones");

                entity.Property(e => e.IdTipoHabitacion)
                    .HasColumnName("id_tipo_habitacion")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioNoche)
                    .HasColumnName("precio_noche")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Usuario)
                    .HasName("PK__usuarios__9AFF8FC7B05DDE03");

                entity.ToTable("usuarios");

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasColumnName("contrasena")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioActivo).HasColumnName("usuario_activo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
