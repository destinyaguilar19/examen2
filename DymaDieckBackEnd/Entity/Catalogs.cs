using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Newtonsoft.Json;

namespace DymaDieckBackend.Entity
{
    #region Users
    [Table("vwUsuario")]
    public class vwUsuario
    {
        [Key]
        public long NPK_Usuario { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Token { get; set; }
        public int? Administrador { get; set; }
        public int? Vendedor { get; set; }
        public int? Almacen { get; set; }
        public string TipoUsuario { get; set; }
    }
    [Table("SecUsers")]
    public class SecUsersCatalog
    {
        [Key]
        public long NPK_User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Charge { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? Active { get; set; }
    }
    #endregion


    #region Empresa
    [Table("vwEmpresa")]
    public class vwEmpresa
    {
        [Key]
        public int NPK_Empresa { get; set; }
        public string id { get; set; }
        public string NombreEmpresa { get; set; }
        public string text { get; set; }

        public string RazonSocial { get; set; }

        public string Calle { get; set; }

        public string NumeroExterior { get; set; }

        public string NumeroInterior { get; set; }

        public string Colonia { get; set; }

        public string Ciudad { get; set; }

        public string Estado { get; set; }

        public string CodigoPostal { get; set; }

        public string RFC { get; set; }

        public string CURP { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Empresa")]
    public class EmpresaCatalogo
    {
        [Key]
        public long NPK_Empresa { get; set; }

        public string NombreEmpresa { get; set; }

        public string RazonSocial { get; set; }

        public string Calle { get; set; }

        public string NumeroExterior { get; set; }

        public string NumeroInterior { get; set; }

        public string Colonia { get; set; }

        public string Ciudad { get; set; }

        public string Estado { get; set; }

        public string CodigoPostal { get; set; }

        public string RFC { get; set; }

        public string CURP { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
    #endregion
    #region Empleado
    [Table("vwEmpleado")]
    public class vwEmpleado
    {
        [Key]
        public int NPK_Empleado { get; set; }
        public long NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Nombres { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public DateTime? FechaNacimiento { get; set; }
        public string FechaNacimientoText { get; set; }

        public DateTime FechaIngresoDieck { get; set; }
        public string FechaIngresoText { get; set; }

        public int NFK_TipoEmpleado { get; set; }
        public string TipoEmpleado { get; set; }

        public string Curp { get; set; }

        public string NumeroIMSS { get; set; }

        public string RFC { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Empleado")]
    public class EmpleadoCatalogo
    {
        [Key]
        public long NPK_Empleado { get; set; }
        public long NFK_Empresa { get; set; }

        public string Nombres { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public DateTime FechaIngresoDieck { get; set; }

        public int NFK_TipoEmpleado { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string Curp { get; set; }

        public string NumeroIMSS { get; set; }

        public string RFC { get; set; }
    }
    #endregion
    #region TipoEmpleado
    [Table("vwTipoEmpleado")]
    public class vwTipoEmpleado
    {
        [Key]
        public int NPK_TipoEmpleado { get; set; }

        public string TipoEmpleado { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("TipoEmpleado")]
    public class TipoEmpleadoCatalogo
    {
        [Key]
        public long NPK_TipoEmpleado { get; set; }

        public string TipoEmpleado { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }

    #endregion
    #region Instalador
    [Table("vwInstalador")]
    public class vwInstalador
    {
        [Key]
        public int NPK_Instalador { get; set; }

        public string Nombres { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Direccion { get; set; }

        public string RFC { get; set; }

        public string Telefonos { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public DateTime? FechaNacimiento { get; set; }
        public string FechaNacimientoTexto { get; set; }

        public string NumeroIMSS { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Instalador")]
    public class InstaladorCatalogo
    {
        [Key]
        public long NPK_Instalador { get; set; }

        public string Nombres { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Direccion { get; set; }

        public string RFC { get; set; }

        public string Telefonos { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string NumeroIMSS { get; set; }
    }
    #endregion
    #region RegistroIMSS
    [Table("vwRegistroIMSS")]
    public class vwRegistroIMSS
    {
        [Key]
        public int NPK_Registro_IMSS { get; set; }

        public string Registro_IMSS { get; set; }

        public int? NFK_Empleado { get; set; }
        public string Empleado { get; set; }

        public int? NFK_Instalador { get; set; }
        public string Instalador { get; set; }

        public int NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public DateTime Fecha_Inicio { get; set; }
        public string Fecha_InicioDesc { get; set; }


        public DateTime Fecha_Fin_Periodo { get; set; }
        public string Fecha_Fin_PeriodoDesc { get; set; }

        public string Comentarios { get; set; }

        public decimal? Salario { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
        public string NumeroIMSS { get; set; }
    }
    [Table("RegistroIMSS")]
    public class RegistroIMSSCatalogo
    {
        [Key]
        public long NPK_Registro_IMSS { get; set; }

        public string Registro_IMSS { get; set; }

        public int? NFK_Empleado { get; set; }

        public int? NFK_Instalador { get; set; }

        public int NFK_Empresa { get; set; }

        public DateTime Fecha_Inicio { get; set; }

        public DateTime Fecha_Fin_Periodo { get; set; }

        public string Comentarios { get; set; }

        public decimal? Salario { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
    #endregion
    #region Material
    [Table("vwMaterial")]
    public class vwMaterial
    {
        [Key]
        public int NPK_Material { get; set; }

        public string Material { get; set; }

        public decimal Precio { get; set; }

        public int? NFK_UnidadMedida { get; set; }
        public string UnidadMedida { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Material")]
    public class MaterialCatalogo
    {
        [Key]
        public long NPK_Material { get; set; }

        public string Material { get; set; }

        public decimal Precio { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_UnidadMedida { get; set; }
    }
    #endregion
    #region UnidadMedida
    [Table("vwUnidadMedida")]
    public class vwUnidadMedida
    {
        [Key]
        public int NPK_UnidadMedida { get; set; }

        public string UnidadMedida { get; set; }

        public string CveUnidadMedida { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("UnidadMedida")]
    public class UnidadMedidaCatalogo
    {
        [Key]
        public long NPK_UnidadMedida { get; set; }

        public string UnidadMedida { get; set; }

        public string CveUnidadMedida { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }

    }
    #endregion
    #region Categoria
    [Table("vwCategorias")]
    public class vwCategorias
    {
        [Key]
        public int NPK_Categoria { get; set; }

        public string Categoria { get; set; }

        public string CveCategoria { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Categorias")]
    public class CategoriasCatalogo
    {
        [Key]
        public long NPK_Categoria { get; set; }

        public string Categoria { get; set; }

        public string CveCategoria { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }



    #endregion
    #region Espesor
    [Table("vwEspesor")]
    public class vwEspesor
    {
        [Key]
        public int NPK_Espesor { get; set; }

        public string Espesor { get; set; }

        public string CveEspesor { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Espesor")]
    public class EspesorCatalogo
    {
        [Key]
        public long NPK_Espesor { get; set; }

        public string Espesor { get; set; }

        public string CveEspesor { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }



    #endregion
    #region Formapago
    [Table("vwFormapago")]
    public class vwFormapago
    {
        [Key]
        public int NPK_FormaPago { get; set; }

        public string FormaPago { get; set; }

        public string CveFormaPago { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Formapago")]
    public class FormapagoCatalogo
    {
        [Key]
        public long NPK_FormaPago { get; set; }

        public string FormaPago { get; set; }

        public string CveFormaPago { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }


    #endregion
    #region Cliente
    [Table("vwCliente")]
    public class vwCliente
    {
        [Key]
        public int NPK_Cliente { get; set; }
        public string id { get; set; }
        public string text { get; set; }
        public string NombreCorto { get; set; }

        public string NombreCliente { get; set; }

        public string CveCliente { get; set; }

        public string Calle { get; set; }

        public string NumeroExterior { get; set; }

        public string NumeroInterior { get; set; }

        public string Colonia { get; set; }

        public string Ciudad { get; set; }

        public string CodigoPostal { get; set; }

        public string Estado { get; set; }

        public string SitioWeb { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string TipoPersona { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Entrecalles { get; set; }

        public string TelefonoCasa { get; set; }

        public string TelefonoNegocio { get; set; }

        public string TelefonoNegocio1 { get; set; }

        public string TelefonoCelular { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Contacto { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Cliente")]
    public class ClienteCatalogo
    {
        [Key]
        public long NPK_Cliente { get; set; }

        public string NombreCorto { get; set; }

        public string NombreCliente { get; set; }

        public string CveCliente { get; set; }

        public string Calle { get; set; }

        public string NumeroExterior { get; set; }

        public string NumeroInterior { get; set; }

        public string Colonia { get; set; }

        public string Ciudad { get; set; }

        public string CodigoPostal { get; set; }

        public string Estado { get; set; }

        public string SitioWeb { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string TipoPersona { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Entrecalles { get; set; }

        public string TelefonoCasa { get; set; }

        public string TelefonoNegocio { get; set; }

        public string TelefonoNegocio1 { get; set; }

        public string TelefonoCelular { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Contacto { get; set; }
    }
    #endregion
    #region Fleteroterrestre
    [Table("Fleteroterrestre")]
    public class FleteroterrestreCatalogo
    {
        [Key]
        public long NPK_FleteroTerrestre { get; set; }

        public string FleteroTerrestre { get; set; }

        public string Direccion { get; set; }

        public string Telefonos { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int NFK_Empresa { get; set; }
    }

    [Table("vwFleteroterrestre")]
    public class vwFleteroterrestre
    {
        [Key]
        public int NPK_FleteroTerrestre { get; set; }

        public string FleteroTerrestre { get; set; }

        public string Direccion { get; set; }

        public string Telefonos { get; set; }

        public int NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }


    #endregion
    #region Forwarder
    [Table("vwForwarder")]
    public class vwForwarder
    {
        [Key]
        public int NPK_Forwarder { get; set; }

        public string Forwarder { get; set; }

        public string Direccion { get; set; }

        public string Telefonos { get; set; }

        public int NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Forwarder")]
    public class ForwarderCatalogo
    {
        [Key]
        public long NPK_Forwarder { get; set; }

        public string Forwarder { get; set; }

        public string Direccion { get; set; }

        public string Telefonos { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int NFK_Empresa { get; set; }
    }



    #endregion
    #region Herramienta
    [Table("vwHerramienta")]
    public class vwHerramienta
    {
        [Key]
        public int NPK_Herramienta { get; set; }

        public string Herramienta { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public decimal Precio { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Herramienta")]
    public class HerramientaCatalogo
    {
        [Key]
        public long NPK_Herramienta { get; set; }

        public string Herramienta { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public decimal Precio { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }


    #endregion
    #region Iva
    [Table("vwIva")]
    public class vwIva
    {
        [Key]
        public int NPK_IVA { get; set; }

        public int IVA { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public decimal? PorcentajeAgregar { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Iva")]
    public class IvaCatalogo
    {
        [Key]
        public long NPK_Iva { get; set; }

        public int IVA { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }

        public decimal? PorcentajeAgregar { get; set; }
    }

    #endregion
    #region Medida
    [Table("vwMedida")]
    public class vwMedida
    {
        [Key]
        public int NPK_Medida { get; set; }

        public string Medida { get; set; }

        public string CveMedida { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }

    [Table("Medida")]
    public class MedidaCatalogo
    {
        [Key]
        public long NPK_Medida { get; set; }

        public string Medida { get; set; }

        public string CveMedida { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }
    #endregion
    #region Moneda
    [Table("vwMoneda")]
    public class vwMoneda
    {
        [Key]
        public int NPK_Moneda { get; set; }

        public string Moneda { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Moneda")]
    public class MonedaCatalogo
    {
        [Key]
        public long NPK_Moneda { get; set; }

        public string Moneda { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }
    #endregion
    #region Motivodevolucion
    [Table("vwMotivodevolucion")]
    public class vwMotivodevolucion
    {
        [Key]
        public int NPK_MotivoDevolucion { get; set; }

        public string MotivoDevolucion { get; set; }

        public string CveMotivoDevolucion { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Motivodevolucion")]
    public class MotivodevolucionCatalogo
    {
        [Key]
        public long NPK_MotivoDevolucion { get; set; }

        public string MotivoDevolucion { get; set; }

        public string CveMotivoDevolucion { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }


    #endregion
    #region Naviera
    [Table("vwNaviera")]
    public class vwNaviera
    {
        [Key]
        public int NPK_Naviera { get; set; }

        public string Naviera { get; set; }

        public string Direccion { get; set; }

        public string Telefonos { get; set; }

        public int NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Naviera")]
    public class NavieraCatalogo
    {
        [Key]
        public long NPK_Naviera { get; set; }

        public string Naviera { get; set; }

        public string Direccion { get; set; }

        public string Telefonos { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int NFK_Empresa { get; set; }
    }



    #endregion
    #region Paisorigen
    [Table("vwPaisOrigen")]
    public class vwPaisOrigen
    {
        [Key]
        public int NPK_PaisOrigen { get; set; }

        public string PaisOrigen { get; set; }

        public string CvePais { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }

    [Table("PaisOrigen")]
    public class PaisOrigenCatalogo
    {
        [Key]
        public long NPK_PaisOrigen { get; set; }

        public string PaisOrigen { get; set; }

        public string CvePais { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }


    #endregion
    #region Producto
    [Table("vwProducto")]
    public class vwProducto
    {
        [Key]
        public int NPK_Producto { get; set; }

        public string NombreMaterialDieck { get; set; }

        public string Nombrecompetencia { get; set; }

        public string Nombreoriginal { get; set; }

        public int NFK_Categoria { get; set; }
        public string Categoria { get; set; }
        public int NFK_SubCategoria { get; set; }
        public string SubCategoria { get; set; }

        public int NFK_TipoAcabado { get; set; }
        public string TipoAcabado { get; set; }

        public int NFK_PaisOrigen { get; set; }
        public string PaisOrigen { get; set; }

        public int NFK_Medida { get; set; }
        public string Medida { get; set; }

        public int NFK_Espesor { get; set; }
        public string Espesor { get; set; }

        public int NFK_UnidadMedida { get; set; }
        public string UnidadMedida { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int? ParametrosPlaca { get; set; }

        public string CveCodigoBarra { get; set; }

        public string Color { get; set; }

        public int? Estatus { get; set; }

        public int? NFK_Moneda { get; set; }
        public string Moneda { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Producto")]
    public class ProductoCatalogo
    {
        [Key]
        public long NPK_Producto { get; set; }

        public string NombreMaterialDieck { get; set; }

        public string Nombrecompetencia { get; set; }

        public string Nombreoriginal { get; set; }

        public int NFK_Categoria { get; set; }

        public int NFK_SubCategoria { get; set; }

        public int NFK_TipoAcabado { get; set; }

        public int NFK_PaisOrigen { get; set; }

        public int NFK_Medida { get; set; }

        public int NFK_Espesor { get; set; }

        public int NFK_UnidadMedida { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }

        public int? ParametrosPlaca { get; set; }

        public string CveCodigoBarra { get; set; }

        public string Color { get; set; }

        public int? Estatus { get; set; }

        public int? NFK_Moneda { get; set; }
    }



    #endregion
    #region Proveedor
    [Table("vwProveedor")]
    public class vwProveedor
    {
        [Key]
        public int NPK_Proveedor { get; set; }

        public string NombreProveedor { get; set; }

        public string Direccion { get; set; }

        public string Telefonos { get; set; }

        public int NFK_PaisOrigen { get; set; }
        public string PaisOrigen { get; set; }
        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public string CveCodigoBarra { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Proveedor")]
    public class ProveedorCatalogo
    {
        [Key]
        public long NPK_Proveedor { get; set; }

        public string NombreProveedor { get; set; }

        public string Direccion { get; set; }

        public string Telefonos { get; set; }

        public int NFK_PaisOrigen { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }

        public string CveCodigoBarra { get; set; }
    }


    #endregion
    #region Servicio
    [Table("vwServicio")]
    public class vwServicio
    {
        [Key]
        public int NPK_Servicio { get; set; }

        public string Servicio { get; set; }

        public string Descripcion { get; set; }

        public string TipoMedida { get; set; }

        public int NFK_Moneda { get; set; }
        public string Moneda { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Servicio")]
    public class ServicioCatalogo
    {
        [Key]
        public long NPK_Servicio { get; set; }

        public string Servicio { get; set; }

        public string Descripcion { get; set; }

        public string TipoMedida { get; set; }

        public int NFK_Moneda { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }


    #endregion
    #region Subcategoria
    [Table("vwSubcategoria")]
    public class vwSubCategoria
    {
        [Key]
        public int NPK_SubCategoria { get; set; }

        public int NFK_Categoria { get; set; }
        public string Categoria { get; set; }

        public string SubCategoria { get; set; }

        public string CveSubCategoria { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Subcategorias")]
    public class SubCategoriasCatalogo
    {
        [Key]
        public long NPK_SubCategoria { get; set; }

        public int NFK_Categoria { get; set; }

        public string SubCategoria { get; set; }

        public string CveSubCategoria { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }


    #endregion
    #region TipoAcabado
    [Table("vwTipoAcabado")]
    public class vwTipoAcabado
    {
        [Key]
        public int NPK_TipoAcabado { get; set; }

        public string TipoAcabado { get; set; }

        public string CveTipoAcabado { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("TipoAcabado")]
    public class TipoAcabadoCatalogo
    {
        [Key]
        public long NPK_TipoAcabado { get; set; }

        public string TipoAcabado { get; set; }

        public string CveTipoAcabado { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }


    #endregion
    #region TipoComentario
    [Table("vwTipoComentario")]
    public class vwTipoComentario
    {
        [Key]
        public int NPK_TipoComentario { get; set; }

        public string TipoComentario { get; set; }

        public string CveTipoComentario { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("TipoComentario")]
    public class TipoComentarioCatalogo
    {
        [Key]
        public long NPK_TipoComentario { get; set; }

        public string TipoComentario { get; set; }

        public string CveTipoComentario { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }


    #endregion
    #region TipoDevolucion
    [Table("vwTipoDevolucion")]
    public class vwTipoDevolucion
    {
        [Key]
        public int NPK_TipoDevolucion { get; set; }

        public string TipoDevolucion { get; set; }

        public string CveTipoDevolucion { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("TipoDevolucion")]
    public class TipoDevolucionCatalogo
    {
        [Key]
        public long NPK_TipoDevolucion { get; set; }

        public string TipoDevolucion { get; set; }

        public string CveTipoDevolucion { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }


    #endregion
    #region TipoEmbarque
    [Table("vwTipoEmbarque")]
    public class vwTipoEmbarque
    {
        [Key]
        public int NPK_TipoEmbarque { get; set; }

        public string TipoEmbarque { get; set; }

        public string CveTipoEmbarque { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("TipoEmbarque")]
    public class TipoEmbarqueCatalogo
    {
        [Key]
        public long NPK_TipoEmbarque { get; set; }

        public string TipoEmbarque { get; set; }

        public string CveTipoEmbarque { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }


    #endregion
    #region TipoMovimientoInventario
    [Table("vwTipoMovimientoInventario")]
    public class vwTipoMovimientoInventario
    {
        [Key]
        public int NPK_TipoMovimientoInventario { get; set; }

        public string TipoMovimiento { get; set; }

        public string Tipo { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("TipoMovimientoInventario")]
    public class TipoMovimientoInventarioCatalogo
    {
        [Key]
        public long NPK_TipoMovimientoInventario { get; set; }

        public string TipoMovimiento { get; set; }

        public string Tipo { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }


    #endregion
    #region TipoPago
    [Table("vwTipoPago")]
    public class vwTipoPago
    {
        [Key]
        public int NPK_TipoPago { get; set; }

        public string TipoPago { get; set; }

        public string Descripcion { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("TipoPago")]
    public class TipoPagoCatalogo
    {
        [Key]
        public long NPK_TipoPago { get; set; }

        public string TipoPago { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }


    #endregion
    #region TipoProducto
    [Table("vwTipoProducto")]
    public class vwTipoProducto
    {
        [Key]
        public int NPK_TipoProducto { get; set; }

        public string TipoProducto { get; set; }

        public string CveTipoProducto { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("TipoProducto")]
    public class TipoProductoCatalogo
    {
        [Key]
        public long NPK_TipoProducto { get; set; }

        public string TipoProducto { get; set; }

        public string CveTipoProducto { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }


    #endregion
    #region TipoProveedor
    [Table("vwTipoProveedor")]
    public class vwTipoProveedor
    {
        [Key]
        public int NPK_TipoProveedor { get; set; }

        public string TipoProveedor { get; set; }

        public string CveTipoProveedor { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("TipoProveedor")]
    public class TipoProveedorCatalogo
    {
        [Key]
        public long NPK_TipoProveedor { get; set; }

        public string TipoProveedor { get; set; }

        public string CveTipoProveedor { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }


    #endregion
    #region TipoVenta
    [Table("vwTipoVenta")]
    public class vwTipoVenta
    {
        [Key]
        public int NPK_TipoVenta { get; set; }

        public string TipoVenta { get; set; }

        public string CveTipoVenta { get; set; }

        public string Descripcion { get; set; }

        public int? NFK_Empresa { get; set; }
        public string NombreEmpresa { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("TipoVenta")]
    public class TipoVentaCatalogo
    {
        [Key]
        public long NPK_TipoVenta { get; set; }

        public string TipoVenta { get; set; }

        public string CveTipoVenta { get; set; }

        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? NFK_Empresa { get; set; }
    }


    #endregion
    #region Usuario
    [Table("vwUsuario")]
    public class vwUsuarioCat
    {
        [Key]
        public int NPK_Usuario { get; set; }

        public string id { get; set; }
        public string text { get; set; }
        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Usuario { get; set; }

        public string contraseña { get; set; }

        public int? Administrador { get; set; }

        public int? Vendedor { get; set; }

        public int? Almacen { get; set; }

        public string TipoUsuario { get; set; }

        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Activo { get; set; }
    }
    [Table("Usuario")]
    public class UsuarioCatalogo
    {
        [Key]
        public long NPK_Usuario { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Usuario { get; set; }

        public string contraseña { get; set; }

        public int? Administrador { get; set; }

        public int? Vendedor { get; set; }

        public int? Almacen { get; set; }

        public int Activo { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string TipoUsuario { get; set; }
    }


    #endregion
    #region Venta
    [Table("vwVenta")]

    public class vwVenta
    {
        [Key]
        public int NPK_Venta { get; set; }
        public int NFK_Cliente { get; set; }
        public int NFK_Vendedor { get; set; }
        public string Vendedor { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public int FolioVenta { get; set; }
        public short Activo { get; set; }
        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int NFK_Empresa { get; set; }
        public string Estatus { get; set; }
        public string Proyecto { get; set; }
        public int Creador { get; set; }
    }

    [Table("Venta")]
    public class VentaCatalogo
    {
        [Key]
        public long NPK_Venta { get; set; }
        public int NFK_Cliente { get; set; }
        public int NFK_Vendedor { get; set; }
        public DateTime FechaVenta { get; set; }
        public int FolioVenta { get; set; }
        public int Activo { get; set; }
        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int NFK_Empresa { get; set; }
        public string Estatus { get; set; }
        public string Proyecto { get; set; }
        public int Creador { get; set; }

    }

    #endregion
    #region Ventadetalle
    [Table("vwVentadetalle")]

    public class vwVentadetalle
    {
        [Key]
        public int NPK_VentaDetalle { get; set; }
        public int NFK_Venta { get; set; }
        public int NFK_UnidadMedida { get; set; }
        public string UnidadMedida { get; set; }
        public int NFK_Moneda { get; set; }
        public string Moneda { get; set; }
        public int NFK_Iva { get; set; }
        public int IVA { get; set; }
        public int NFK_Anticipo { get; set; }
        public int Anticipo { get; set; }
        public int NFK_Producto { get; set; }
        public string Producto { get; set; }
        public decimal Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }
        public short EntregadoAlmacen { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Factura { get; set; }
        public short AvanceObra { get; set; }
        public int Esdevolucion { get; set; }

    }

    [Table("Ventadetalle")]

    public class VentadetalleCatalogo
    {
        public long NPK_VentaDetalle { get; set; }
        public int NFK_Venta { get; set; }
        public int NFK_UnidadMedida { get; set; }
        public int NFK_Moneda { get; set; }
        public int NFK_Iva { get; set; }
        public int NFK_Anticipo { get; set; }
        public int NFK_Producto { get; set; }
        public decimal Cantidad { get; set; }
        public string Producto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public short EntregadoAlmacen { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public short Factura { get; set; }
        public short AvanceObra { get; set; }
        public int Esdevolucion { get; set; }

    }
    #endregion
    #region Cotizacion
    [Table("vwCotizacion")]

    public class vwCotizacion
    {
        [Key]
        public int NPK_Cotizacion { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public short Activo { get; set; }
        public int CreadoPor { get; set; }
        public string id { get; set; }
        public string text { get; set; }
        public string vendedor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int Creador { get; set; }
        public string Cliente { get; set; }

    }
    [Table("Cotizacion")]

    public class CotizacionCatalogo
    {
        public long NPK_Cotizacion { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public short Activo { get; set; }
        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int Creador { get; set; }
        public string Cliente { get; set; }
    }
}
        
    
    #endregion
    
