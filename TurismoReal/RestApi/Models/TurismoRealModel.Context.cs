﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CLIENTE> CLIENTE { get; set; }
        public virtual DbSet<COMUNA> COMUNA { get; set; }
        public virtual DbSet<DEPARTAMENTO> DEPARTAMENTO { get; set; }
        public virtual DbSet<DETALLE_RESERVA> DETALLE_RESERVA { get; set; }
        public virtual DbSet<EMPLEADO> EMPLEADO { get; set; }
        public virtual DbSet<ENTORNO> ENTORNO { get; set; }
        public virtual DbSet<ESTADO> ESTADO { get; set; }
        public virtual DbSet<FACTURA> FACTURA { get; set; }
        public virtual DbSet<IMAGEN> IMAGEN { get; set; }
        public virtual DbSet<INVENTARIO> INVENTARIO { get; set; }
        public virtual DbSet<PAQUETE_PRODUCTO> PAQUETE_PRODUCTO { get; set; }
        public virtual DbSet<PASAJERO> PASAJERO { get; set; }
        public virtual DbSet<PROVINCIA> PROVINCIA { get; set; }
        public virtual DbSet<REGION> REGION { get; set; }
        public virtual DbSet<RESERVA> RESERVA { get; set; }
        public virtual DbSet<SERVICIO> SERVICIO { get; set; }
        public virtual DbSet<SUCURSAL> SUCURSAL { get; set; }
        public virtual DbSet<TIPO_USUARIO> TIPO_USUARIO { get; set; }
        public virtual DbSet<TOUR> TOUR { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<VALORACION> VALORACION { get; set; }
    }
}