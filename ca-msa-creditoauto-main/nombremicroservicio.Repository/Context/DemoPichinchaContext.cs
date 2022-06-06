using Microsoft.EntityFrameworkCore;
using nombremicroservicio.Entities.Model;

namespace nombremicroservicio.Repository.Context
{
    public partial class DemoPichinchaContext : DbContext
    {
        public DemoPichinchaContext(DbContextOptions<DemoPichinchaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignacioncliente> Asignacionclientes { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Ejecutivo> Ejecutivos { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Patio> Patios { get; set; }
        public virtual DbSet<SolicitudCredito> SolicitudCreditos { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Asignacioncliente>(entity =>
            {
                entity.HasKey(e => e.AcId);

                entity.ToTable("Asignacioncliente");

                entity.Property(e => e.AcId).HasColumnName("ac_Id");

                entity.Property(e => e.AcFechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("ac_fecha_creacion");

                entity.Property(e => e.AcIdPatio).HasColumnName("ac_id_Patio");

                entity.Property(e => e.AcIdentificacionCliente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ac_Identificacion_cliente");

                entity.HasOne(d => d.AcIdPatioNavigation)
                    .WithMany(p => p.Asignacionclientes)
                    .HasForeignKey(d => d.AcIdPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignacioncliente_Patio");

                entity.HasOne(d => d.AcIdentificacionClienteNavigation)
                    .WithMany(p => p.Asignacionclientes)
                    .HasForeignKey(d => d.AcIdentificacionCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asignacioncliente_Cliente");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.ClIdentificacion)
                    .HasName("PK_Cliente_1");

                entity.ToTable("Cliente");

                entity.Property(e => e.ClIdentificacion)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cl_identificacion");

                entity.Property(e => e.ClApellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cl_apellidos");

                entity.Property(e => e.ClDireccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cl_direccion");

                entity.Property(e => e.ClEdad).HasColumnName("cl_edad");

                entity.Property(e => e.ClEstadoCivil).HasColumnName("cl_estado_civil");

                entity.Property(e => e.ClFechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("cl_fecha_nacimiento");

                entity.Property(e => e.ClIdentificacionConyugue)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cl_identificacion_conyugue");

                entity.Property(e => e.ClNombreConyugue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cl_nombre_conyugue");

                entity.Property(e => e.ClNombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cl_nombres");

                entity.Property(e => e.ClSujetoCredito).HasColumnName("cl_sujeto_credito");

                entity.Property(e => e.ClTelefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cl_telefono");
            });

            modelBuilder.Entity<Ejecutivo>(entity =>
            {
                entity.HasKey(e => e.EjIdentificacion)
                    .HasName("PK_Ejecutivo_1");

                entity.ToTable("Ejecutivo");

                entity.Property(e => e.EjIdentificacion)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ej_identificacion");

                entity.Property(e => e.EjApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ej_apellido");

                entity.Property(e => e.EjCelular)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ej_celular");

                entity.Property(e => e.EjDireccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ej_direccion");

                entity.Property(e => e.EjEdad).HasColumnName("ej_edad");

                entity.Property(e => e.EjNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ej_nombre");

                entity.Property(e => e.EjPatio).HasColumnName("ej_Patio");

                entity.Property(e => e.EjTelefono)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ej_telefono");

                entity.HasOne(d => d.EjPatioNavigation)
                    .WithMany(p => p.Ejecutivos)
                    .HasForeignKey(d => d.EjPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ejecutivo_Patio");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.MaId);

                entity.ToTable("Marca");

                entity.Property(e => e.MaId).HasColumnName("ma_id");

                entity.Property(e => e.MaNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ma_nombre");
            });

            modelBuilder.Entity<Patio>(entity =>
            {
                entity.HasKey(e => e.PaId);

                entity.ToTable("Patio");

                entity.Property(e => e.PaId).HasColumnName("pa_id");

                entity.Property(e => e.PaDireccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pa_direccion");

                entity.Property(e => e.PaNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pa_nombre");

                entity.Property(e => e.PaNumeroPuntoVenta).HasColumnName("pa_numero_punto_venta");

                entity.Property(e => e.PaTelefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pa_telefono");
            });

            modelBuilder.Entity<SolicitudCredito>(entity =>
            {
                entity.HasKey(e => e.ScId);

                entity.ToTable("SolicitudCredito");

                entity.Property(e => e.ScId).HasColumnName("sc_id");

                entity.Property(e => e.ScCuotas).HasColumnName("sc_cuotas");

                entity.Property(e => e.ScEntrada)
                    .HasColumnType("money")
                    .HasColumnName("sc_entrada");

                entity.Property(e => e.ScEstado).HasColumnName("sc_estado");

                entity.Property(e => e.ScIdentificacionCliente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sc_identificacion_cliente");

                entity.Property(e => e.ScIdentificacionEjecutivo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sc_identificacion_ejecutivo");

                entity.Property(e => e.ScMesesPlazo).HasColumnName("sc_meses_plazo");

                entity.Property(e => e.ScObservacion)
                    .IsUnicode(false)
                    .HasColumnName("sc_observacion");

                entity.Property(e => e.ScPatio).HasColumnName("sc_Patio");

                entity.Property(e => e.ScVehiculo).HasColumnName("sc_Vehiculo");

                entity.HasOne(d => d.ScIdentificacionClienteNavigation)
                    .WithMany(p => p.SolicitudCreditos)
                    .HasForeignKey(d => d.ScIdentificacionCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolicitudCredito_Cliente");

                entity.HasOne(d => d.ScIdentificacionEjecutivoNavigation)
                    .WithMany(p => p.SolicitudCreditos)
                    .HasForeignKey(d => d.ScIdentificacionEjecutivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolicitudCredito_Ejecutivo");

                entity.HasOne(d => d.ScPatioNavigation)
                    .WithMany(p => p.SolicitudCreditos)
                    .HasForeignKey(d => d.ScPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolicitudCredito_Patio");

                entity.HasOne(d => d.ScVehiculoNavigation)
                    .WithMany(p => p.SolicitudCreditos)
                    .HasForeignKey(d => d.ScVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolicitudCredito_Vehiculo");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.VeId);

                entity.ToTable("Vehiculo");

                entity.Property(e => e.VeId).HasColumnName("ve_id");

                entity.Property(e => e.VeAvaluo)
                    .HasColumnType("money")
                    .HasColumnName("ve_avaluo");

                entity.Property(e => e.VeCilindraje)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ve_cilindraje");

                entity.Property(e => e.VeMarcaId).HasColumnName("ve_marca_id");

                entity.Property(e => e.VeModelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ve_modelo");

                entity.Property(e => e.VeNumeroChasis)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ve_numero_chasis");

                entity.Property(e => e.VePlaca)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ve_placa");

                entity.Property(e => e.VeTipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ve_tipo");

                entity.HasOne(d => d.VeMarca)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.VeMarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_Marca");
            });

        }
    }
}
