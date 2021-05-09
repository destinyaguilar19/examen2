using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DymaDieckAPI.Models
{
    #region TypeEquipmentForm
    public class ServiceTypesForm
    {
        [Required]
        public int NPK_ServiceType { get; set; }
        [Required]
        public string ServiceTypeName { get; set; }
        [Required]
        public string ServiceTypeCode { get; set; }
        [Required]
        public string Description { get; set; }
    }
    #endregion
    
    #region Emoresa
    public class EmpresaForm
    {
        [Required]
        public int NPK_Empresa { get; set; }
        [Required]
        public string NombreEmpresa { get; set; }
        [Required]
        public string RazonSocial { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        public string NumeroExterior { get; set; }

        public string NumeroInterior { get; set; }
        [Required]
        public string Colonia { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        public string Estado { get; set; }

        public string CodigoPostal { get; set; }
        [Required]
        public string RFC { get; set; }

        public string CURP { get; set; }
    }
    #endregion
    #region Empleado
    public class EmpleadoForm
    {
        [Required]
        public int NPK_Empleado { get; set; }
        [Required]
        public int NFK_Empresa { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public DateTime FechaNacimiento { get; set; }
        [Required]
        public DateTime FechaIngresoDieck { get; set; }
        [Required]
        public int NFK_TipoEmpleado { get; set; }

        public string Curp { get; set; }

        public string NumeroIMSS { get; set; }

        public string RFC { get; set; }
    }
    #endregion
    #region TipoEmpleado
    public class TipoEmpleadoForm
    {
        [Required]
        public int NPK_TipoEmpleado { get; set; }
        [Required]
        public string TipoEmpleado { get; set; }
    }


    #endregion
    #region Instalador
    public class InstaladorForm
    {
        [Required]
        public int NPK_Instalador { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Direccion { get; set; }

        public string RFC { get; set; }

        public string Telefonos { get; set; }

        public int NFK_Empresa { get; set; }
        

        public DateTime FechaNacimiento { get; set; }

        public string NumeroIMSS { get; set; }
    }
    #endregion
    #region RegistroIMSS
    public class RegistroIMSSForm
    {
        [Required]
        public int NPK_Registro_IMSS { get; set; }
        [Required]
        public string Registro_IMSS { get; set; }

        public int NFK_Empleado { get; set; }

        public int NFK_Instalador { get; set; }
        [Required]
        public int NFK_Empresa { get; set; }
        [Required]
        public DateTime Fecha_Inicio { get; set; }
        [Required]
        public DateTime Fecha_Fin_Periodo { get; set; }

        public string Comentarios { get; set; }

        public decimal Salario { get; set; }
    }
    #endregion
    #region Material
    public class MaterialForm
    {
        [Required]
        public int NPK_Material { get; set; }
        [Required]
        public string Material { get; set; }
        [Required]
        public decimal Precio { get; set; }

        public int NFK_UnidadMedida { get; set; }
    }
    #endregion
    #region UnidadMedida
    public class UnidadMedidaForm
    {
        [Required]
        public int NPK_UnidadMedida { get; set; }
        [Required]
        public string UnidadMedida { get; set; }
        [Required]
        public string CveUnidadMedida { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region Categoria
    public class CategoriasForm
    {
        [Required]
        public int NPK_Categoria { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string CveCategoria { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region Espesor
    public class EspesorForm
    {
        [Required]
        public int NPK_Espesor { get; set; }
        [Required]
        public string Espesor { get; set; }
        [Required]
        public string CveEspesor { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region Formapago
    public class FormapagoForm
    {
        [Required]
        public int NPK_FormaPago { get; set; }
        [Required]
        public string FormaPago { get; set; }
        [Required]
        public string CveFormaPago { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region Cliente
    public class ClienteForm
    {
        [Required]
        public int NPK_Cliente { get; set; }

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
    }

    #endregion
    #region Fleteroterrestre
    public class FleteroterrestreForm
    {
        [Required]
        public int NPK_FleteroTerrestre { get; set; }
        [Required]
        public string FleteroTerrestre { get; set; }

        public string Direccion { get; set; }

        public string Telefonos { get; set; }
        [Required]
        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region Forwarder
    public class ForwarderForm
    {
        [Required]
        public int NPK_Forwarder { get; set; }
        [Required]
        public string Forwarder { get; set; }

        public string Direccion { get; set; }

        public string Telefonos { get; set; }
        [Required]
        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region Herramienta
    public class HerramientaForm
    {
        [Required]
        public int NPK_Herramienta { get; set; }
        [Required]
        public string Herramienta { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }
        [Required]
        public decimal Precio { get; set; }
    }

    #endregion
    #region Iva
    public class IvaForm
    {
        [Required]
        public int NPK_IVA { get; set; }
        [Required]
        public int IVA { get; set; }
        [Required]
        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }

        public decimal PorcentajeAgregar { get; set; }
    }

    #endregion
    #region Medida
    public class MedidaForm
    {
        [Required]
        public int NPK_Medida { get; set; }
        [Required]
        public string Medida { get; set; }
        [Required]
        public string CveMedida { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region Moneda
    public class MonedaForm
    {
        [Required]
        public int NPK_Moneda { get; set; }
        [Required]
        public string Moneda { get; set; }

        public int NFK_Empresa { get; set; }
    }
    #endregion
    #region Motivodevolucion
    public class MotivodevolucionForm
    {
        [Required]
        public int NPK_MotivoDevolucion { get; set; }
        [Required]
        public string MotivoDevolucion { get; set; }
        [Required]
        public string CveMotivoDevolucion { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }
    #endregion
    #region Naviera
    public class NavieraForm
    {
        [Required]
        public int NPK_Naviera { get; set; }
        [Required]
        public string Naviera { get; set; }

        public string Direccion { get; set; }

        public string Telefonos { get; set; }
        [Required]
        public int NFK_Empresa { get; set; }
    }
    #endregion
    #region Paisorigen
    public class PaisOrigenForm
    {
        [Required]
        public int NPK_PaisOrigen { get; set; }
        [Required]
        public string PaisOrigen { get; set; }
        [Required]
        public string CvePais { get; set; }

        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region Producto
    public class ProductoForm
    {
        [Required]
        public int NPK_Producto { get; set; }
        [Required]
        public string NombreMaterialDieck { get; set; }
        [Required]
        public string Nombrecompetencia { get; set; }
        [Required]
        public string Nombreoriginal { get; set; }
        [Required]
        public int NFK_Categoria { get; set; }
        [Required]
        public int NFK_SubCategoria { get; set; }
        [Required]
        public int NFK_TipoAcabado { get; set; }
        [Required]
        public int NFK_PaisOrigen { get; set; }
        [Required]
        public int NFK_Medida { get; set; }
        [Required]
        public int NFK_Espesor { get; set; }
        [Required]
        public int NFK_UnidadMedida { get; set; }

        public int NFK_Empresa { get; set; }

        public int ParametrosPlaca { get; set; }

        public string CveCodigoBarra { get; set; }

        public string Color { get; set; }

        public int Estatus { get; set; }

        public int NFK_Moneda { get; set; }
    }

    #endregion
    #region Proveedor
    public class ProveedorForm
    {
        [Required]
        public int NPK_Proveedor { get; set; }
        [Required]
        public string NombreProveedor { get; set; }
        [Required]
        public string Direccion { get; set; }

        public string Telefonos { get; set; }
        [Required]
        public int NFK_PaisOrigen { get; set; }

        public int NFK_Empresa { get; set; }

        public string CveCodigoBarra { get; set; }
    }

    #endregion
    #region Servicio
    public class ServicioForm
    {
        [Required]
        public int NPK_Servicio { get; set; }
        [Required]
        public string Servicio { get; set; }

        public string Descripcion { get; set; }
        [Required]
        public string TipoMedida { get; set; }
        [Required]
        public int NFK_Moneda { get; set; }
    }

    #endregion
    #region Subcategoria
    public class SubCategoriasForm
    {
        [Required]
        public int NPK_SubCategoria { get; set; }
        [Required]
        public int NFK_Categoria { get; set; }
        [Required]
        public string SubCategoria { get; set; }
        [Required]
        public string CveSubCategoria { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region TipoAcabado
    public class TipoAcabadoForm
    {
        [Required]
        public int NPK_TipoAcabado { get; set; }
        [Required]
        public string TipoAcabado { get; set; }
        [Required]
        public string CveTipoAcabado { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }


    #endregion
    #region TipoComentario
    public class TipoComentarioForm
    {
        [Required]
        public int NPK_TipoComentario { get; set; }
        [Required]
        public string TipoComentario { get; set; }
        [Required]
        public string CveTipoComentario { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region TipoDevolucion
    public class TipoDevolucionForm
    {
        [Required]
        public int NPK_TipoDevolucion { get; set; }
        [Required]
        public string TipoDevolucion { get; set; }
        [Required]
        public string CveTipoDevolucion { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region TipoEmbarque
    public class TipoEmbarqueForm
    {
        [Required]
        public int NPK_TipoEmbarque { get; set; }
        [Required]
        public string TipoEmbarque { get; set; }
        [Required]
        public string CveTipoEmbarque { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region TipoMovimientoInventario
    public class TipoMovimientoInventarioForm
    {
        [Required]
        public int NPK_TipoMovimientoInventario { get; set; }
        [Required]
        public string TipoMovimiento { get; set; }
        [Required]
        public string Tipo { get; set; }
    }

    #endregion
    #region TipoPago
    public class TipoPagoForm
    {
        [Required]
        public int NPK_TipoPago { get; set; }
        [Required]
        public string TipoPago { get; set; }

        public string Descripcion { get; set; }
    }

    #endregion
    #region TipoProducto
    public class TipoProductoForm
    {
        [Required]
        public int NPK_TipoProducto { get; set; }
        [Required]
        public string TipoProducto { get; set; }
        [Required]
        public string CveTipoProducto { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region TipoProveedor
    public class TipoProveedorForm
    {
        [Required]
        public int NPK_TipoProveedor { get; set; }
        [Required]
        public string TipoProveedor { get; set; }
        [Required]
        public string CveTipoProveedor { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region TipoVenta
    public class TipoVentaForm
    {
        [Required]
        public int NPK_TipoVenta { get; set; }
        [Required]
        public string TipoVenta { get; set; }
        [Required]
        public string CveTipoVenta { get; set; }

        public string Descripcion { get; set; }

        public int NFK_Empresa { get; set; }
    }

    #endregion
    #region Usuario
    public class UsuarioForm
    {
        [Required]
        public int NPK_Usuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string contraseña { get; set; }

        public int? Administrador { get; set; }

        public int? Vendedor { get; set; }

        public int? Almacen { get; set; }

        public string TipoUsuario { get; set; }
    }

    #endregion
    #region Venta 
    public class Ventaform
    {
        [Required]
        public int NPK_Venta { get; set; }
        [Required]
        public int NFK_Cliente { get; set; }
        [Required]
        public int NFK_Vendedor { get; set; }
        [Required]
        public DateTime FechaVenta { get; set; }
        [Required]
        public int FolioVenta { get; set; }
        public int NFK_Empresa { get; set; }
        public string Estatus { get; set; }
        public string Proyecto { get; set; }

    }
    #endregion
    #region Ventadetalle
    public class Ventadetalleform
    {
        [Required]
        public long NPK_VentaDetalle { get; set; }
        [Required]
        public int NFK_Venta { get; set; }
        [Required]
        public int NFK_UnidadMedida { get; set; }
        [Required]
        public int NFK_Moneda { get; set; }
        [Required]
        public int NFK_Iva { get; set; }
        [Required]
        public int NFK_Anticipo { get; set; }
        [Required]
        public int NFK_Producto { get; set; }
        [Required]
        public decimal Cantidad { get; set; }
        [Required]
        public decimal PrecioUnitario { get; set; }
        public short EntregadoAlmacen { get; set; }
        public short Factura { get; set; }
        public short AvanceObra { get; set; }
        public int Esdevolucion { get; set; }
    }
    #endregion
    #region cotizacion
    public class Cotizacionform
    {
        [Required]
        public int NPK_Cotizacion { get; set; }
        [Required]
        public DateTime FechaCotizacion { get; set; }
        [Required]
        public string Cliente { get; set; }
    }
   

    #endregion
}