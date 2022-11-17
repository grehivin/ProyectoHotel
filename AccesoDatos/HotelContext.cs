using System;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace AccesoDatos
{
    public partial class HotelContext : DbContext
    {
        private static string connectionString = "Server=tcp:progravan.database.windows.net,1433;Initial Catalog=progravan;Persist Security Info=False;User ID=progravan;Password=Progr4van;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcompanantesReservaciones> AcompanantesReservaciones { get; set; }
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
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AcompanantesReservaciones>(entity =>
            {
                entity.HasKey(e => e.IdInvitadosReservacion)
                    .HasName("PK__acompana__447394593B8F48BF");

                entity.ToTable("acompanantes_reservaciones", "hotel");

                entity.Property(e => e.IdInvitadosReservacion)
                    .HasColumnName("id_invitados_reservacion")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EdadInvitado)
                    .HasColumnName("edad_invitado")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdReservacion)
                    .HasColumnName("id_reservacion")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NombreCompletoInvitado)
                    .IsRequired()
                    .HasColumnName("nombre_completo_invitado")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoInvitado)
                    .IsRequired()
                    .HasColumnName("tipo_invitado")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdReservacionNavigation)
                    .WithMany(p => p.AcompanantesReservaciones)
                    .HasForeignKey(d => d.IdReservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_acompanantes_reservaciones_reservaciones");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__clientes__677F38F52AE88F96");

                entity.ToTable("clientes", "hotel");

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

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Usuario)
                    .HasConstraintName("FK_clientes_usuarios");
            });

            modelBuilder.Entity<Habitaciones>(entity =>
            {
                entity.HasKey(e => e.NumHabitacion)
                    .HasName("PK__habitaco__CA9FE567FB34308D");

                entity.ToTable("habitaciones", "hotel");

                entity.Property(e => e.NumHabitacion)
                    .HasColumnName("num_habitacion")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CapacidadPersonas)
                    .HasColumnName("capacidad_personas")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.HabitacionActiva).HasColumnName("habitacion_activa");

                entity.Property(e => e.PisoHabitacion)
                    .HasColumnName("piso_habitacion")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TipoHabitacion)
                    .HasColumnName("tipo_habitacion")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.TipoHabitacionNavigation)
                    .WithMany(p => p.Habitaciones)
                    .HasForeignKey(d => d.TipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_habitacones_tipos_habitaciones");
            });

            modelBuilder.Entity<Reservaciones>(entity =>
            {
                entity.HasKey(e => e.IdReservacion)
                    .HasName("PK__reservac__786D5E835F9B4A4A");

                entity.ToTable("reservaciones", "hotel");

                entity.Property(e => e.IdReservacion)
                    .HasColumnName("id_reservacion")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CantidadAcompanantes)
                    .HasColumnName("cantidad_acompanantes")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cliente)
                    .HasColumnName("cliente")
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

                entity.Property(e => e.NumHabitacion)
                    .HasColumnName("num_habitacion")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reservaciones_clientes");

                entity.HasOne(d => d.NumHabitacionNavigation)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.NumHabitacion)
                    .HasConstraintName("FK_reservaciones_habitacones");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__roles__6ABCB5E00F5BA411");

                entity.ToTable("roles", "hotel");

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
                entity.ToTable("roles_usuarios", "hotel");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Rol)
                    .HasColumnName("rol")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.RolesUsuarios)
                    .HasForeignKey(d => d.Rol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_roles_usuarios_roles");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.RolesUsuarios)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_roles_usuarios_usuarios");
            });

            modelBuilder.Entity<TiposHabitaciones>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabitacion)
                    .HasName("PK__tipos_ha__41F1419E252AC87D");

                entity.ToTable("tipos_habitaciones", "hotel");

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
                    .HasName("PK__usuarios__9AFF8FC769E8142C");

                entity.ToTable("usuarios", "hotel");

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasColumnName("contrasena")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioActivo).HasColumnName("usuario_activo");
            });
        }
    }
}
