using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DymaDieckBackend;
using DymaDieckBackend.Entity;
using DymaDieckBackend.Repositories;

namespace DymaDieckBackend.Actions
{
    public class Task
    {
        private static string ClientConnectionString = "";
        public Task(string clientConnString)
        {
            ClientConnectionString = clientConnString;
        }
        #region Secutiry
        //public Entity.vwEmployee LoginEmployee(string username, string password)
        //{
        //    var repo = new Repositories.UserRepository(ClientConnectionString);
        //    return repo.ValidateEmployee(username, password);
        //}
        
        //public void SetPushInfoToEmployee(long npkEmployee, string onesigna_userid)
        //{
        //    var repo = new Repositories.UserRepository(ClientConnectionString);
        //    repo.SetEmployeePushInfo(npkEmployee, onesigna_userid);
        //}
        public static Entity.vwUsuario LoginUserWeb(string username, string password)
        {
            var repo = new Repositories.UserRepository(DymaDieckBackend.Util.DbManager.ConnectionString.Connection);
            return repo.AuthenticateUserWeb(username, password);
        }
        #endregion

       
        #region Empresa
        public List<vwEmpresa> TraerEmpresas(int Activo)
        {
            var repo = new Repositories.CatalogRepository(DymaDieckBackend.Util.DbManager.ConnectionString.Connection);
            if (Activo < 2)
                return repo.TraerEmpresas(Activo);
            else
                return repo.TraerEmpresas(null);
        }
        public EmpresaCatalogo GuardarEmpresa(EmpresaCatalogo datos, int NFK_User)
        {
            var repo = new Repositories.CatalogRepository(DymaDieckBackend.Util.DbManager.ConnectionString.Connection);
            datos.Activo = 1;
            return repo.GuardarEmpresa(datos, NFK_User);
        }
        public EmpresaCatalogo GuardarEmpresaActivo(long NPK_Empresa, int Activo, int NFK_User)
        {
            var repo = new Repositories.CatalogRepository(DymaDieckBackend.Util.DbManager.ConnectionString.Connection);
            return repo.GuardarEmpresaActivo(NPK_Empresa, Activo, NFK_User);
        }

        #endregion
        #region TipoEmpleado
        public List<vwTipoEmpleado> TraerTipoEmpleados(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerTipoEmpleados(Activo);
            else
                return repo.TraerTipoEmpleados(null);
        }
        public TipoEmpleadoCatalogo GuardarTipoEmpleado(TipoEmpleadoCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarTipoEmpleado(datos, NFK_User);
        }
        public TipoEmpleadoCatalogo GuardarTipoEmpleadoActivo(long NPK_TipoEmpleado, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarTipoEmpleadoActivo(NPK_TipoEmpleado, Activo, NFK_User);
        }

        #endregion
        #region Empleado
        public List<vwEmpleado> TraerEmpleados(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerEmpleados(Activo);
            else
                return repo.TraerEmpleados(null);
        }
        public EmpleadoCatalogo GuardarEmpleado(EmpleadoCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarEmpleado(datos, NFK_User);
        }
        public EmpleadoCatalogo GuardarEmpleadoActivo(long NPK_Empleado, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarEmpleadoActivo(NPK_Empleado, Activo, NFK_User);
        }

        #endregion
        #region Instalador
        public List<vwInstalador> TraerInstaladors(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerInstaladors(Activo);
            else
                return repo.TraerInstaladors(null);
        }
        public InstaladorCatalogo GuardarInstalador(InstaladorCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarInstalador(datos, NFK_User);
        }
        public InstaladorCatalogo GuardarInstaladorActivo(long NPK_Instalador, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarInstaladorActivo(NPK_Instalador, Activo, NFK_User);
        }

        #endregion
        #region RegistoImss
        public List<vwRegistroIMSS> TraerRegistroIMSSs(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerRegistroIMSSs(Activo);
            else
                return repo.TraerRegistroIMSSs(null);
        }
        public RegistroIMSSCatalogo GuardarRegistroIMSS(RegistroIMSSCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarRegistroIMSS(datos, NFK_User);
        }
        public RegistroIMSSCatalogo GuardarRegistroIMSSActivo(long NPK_RegistroIMSS, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarRegistroIMSSActivo(NPK_RegistroIMSS, Activo, NFK_User);
        }

        #endregion
        #region Material
        public List<vwMaterial> TraerMaterials(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerMaterials(Activo);
            else
                return repo.TraerMaterials(null);
        }
        public MaterialCatalogo GuardarMaterial(MaterialCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarMaterial(datos, NFK_User);
        }
        public MaterialCatalogo GuardarMaterialActivo(long NPK_Material, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarMaterialActivo(NPK_Material, Activo, NFK_User);
        }

        #endregion
        #region UnidadMedida
        public List<vwUnidadMedida> TraerUnidadMedidas(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerUnidadMedidas(Activo);
            else
                return repo.TraerUnidadMedidas(null);
        }
        public UnidadMedidaCatalogo GuardarUnidadMedida(UnidadMedidaCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarUnidadMedida(datos, NFK_User);
        }
        public UnidadMedidaCatalogo GuardarUnidadMedidaActivo(long NPK_UnidadMedida, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarUnidadMedidaActivo(NPK_UnidadMedida, Activo, NFK_User);
        }

        #endregion
        #region Categoria
        public List<vwCategorias> TraerCategoriass(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerCategoriass(Activo);
            else
                return repo.TraerCategoriass(null);
        }
        public CategoriasCatalogo GuardarCategorias(CategoriasCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarCategorias(datos, NFK_User);
        }
        public CategoriasCatalogo GuardarCategoriasActivo(long NPK_Categorias, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarCategoriasActivo(NPK_Categorias, Activo, NFK_User);
        }

        #endregion
        #region Espesor
        public List<vwEspesor> TraerEspesors(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerEspesors(Activo);
            else
                return repo.TraerEspesors(null);
        }
        public EspesorCatalogo GuardarEspesor(EspesorCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarEspesor(datos, NFK_User);
        }
        public EspesorCatalogo GuardarEspesorActivo(long NPK_Espesor, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarEspesorActivo(NPK_Espesor, Activo, NFK_User);
        }

        #endregion
        #region FormaPago
        public List<vwFormapago> TraerFormapagos(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerFormapagos(Activo);
            else
                return repo.TraerFormapagos(null);
        }
        public FormapagoCatalogo GuardarFormapago(FormapagoCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarFormapago(datos, NFK_User);
        }
        public FormapagoCatalogo GuardarFormapagoActivo(long NPK_Formapago, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarFormapagoActivo(NPK_Formapago, Activo, NFK_User);
        }

        #endregion
        #region Cliente
        public List<vwCliente> TraerClientes(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerClientes(Activo);
            else
                return repo.TraerClientes(null);
        }
        public ClienteCatalogo GuardarCliente(ClienteCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarCliente(datos, NFK_User);
        }
        public ClienteCatalogo GuardarClienteActivo(long NPK_Cliente, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarClienteActivo(NPK_Cliente, Activo, NFK_User);
        }

        #endregion
        #region Fleteroterrestre
        public List<vwFleteroterrestre> TraerFleteroterrestres(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerFleteroterrestres(Activo);
            else
                return repo.TraerFleteroterrestres(null);
        }
        public FleteroterrestreCatalogo GuardarFleteroterrestre(FleteroterrestreCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarFleteroterrestre(datos, NFK_User);
        }
        public FleteroterrestreCatalogo GuardarFleteroterrestreActivo(long NPK_Fleteroterrestre, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarFleteroterrestreActivo(NPK_Fleteroterrestre, Activo, NFK_User);
        }

        #endregion
        #region Forwarder
        public List<vwForwarder> TraerForwarders(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerForwarders(Activo);
            else
                return repo.TraerForwarders(null);
        }
        public ForwarderCatalogo GuardarForwarder(ForwarderCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarForwarder(datos, NFK_User);
        }
        public ForwarderCatalogo GuardarForwarderActivo(long NPK_Forwarder, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarForwarderActivo(NPK_Forwarder, Activo, NFK_User);
        }



        #endregion
        #region Herramienta
                public List<vwHerramienta> TraerHerramientas(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerHerramientas(Activo);
            else
                return repo.TraerHerramientas(null);
        }
        public HerramientaCatalogo GuardarHerramienta(HerramientaCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarHerramienta(datos, NFK_User);
        }
        public HerramientaCatalogo GuardarHerramientaActivo(long NPK_Herramienta, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarHerramientaActivo(NPK_Herramienta, Activo, NFK_User);
        }



        #endregion
        #region Iva
        public List<vwIva> TraerIvas(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerIvas(Activo);
            else
                return repo.TraerIvas(null);
        }
        public IvaCatalogo GuardarIva(IvaCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarIva(datos, NFK_User);
        }
        public IvaCatalogo GuardarIvaActivo(long NPK_Iva, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarIvaActivo(NPK_Iva, Activo, NFK_User);
        }

        #endregion
        #region Medida
        public List<vwMedida> TraerMedidas(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerMedidas(Activo);
            else
                return repo.TraerMedidas(null);
        }
        public MedidaCatalogo GuardarMedida(MedidaCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarMedida(datos, NFK_User);
        }
        public MedidaCatalogo GuardarMedidaActivo(long NPK_Medida, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarMedidaActivo(NPK_Medida, Activo, NFK_User);
        }

        #endregion
        #region Moneda
        public List<vwMoneda> TraerMonedas(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerMonedas(Activo);
            else
                return repo.TraerMonedas(null);
        }
        public MonedaCatalogo GuardarMoneda(MonedaCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarMoneda(datos, NFK_User);
        }
        public MonedaCatalogo GuardarMonedaActivo(long NPK_Moneda, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarMonedaActivo(NPK_Moneda, Activo, NFK_User);
        }
        #endregion
        #region Motivodevolucion
        public List<vwMotivodevolucion> TraerMotivodevolucions(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerMotivodevolucions(Activo);
            else
                return repo.TraerMotivodevolucions(null);
        }
        public MotivodevolucionCatalogo GuardarMotivodevolucion(MotivodevolucionCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarMotivodevolucion(datos, NFK_User);
        }
        public MotivodevolucionCatalogo GuardarMotivodevolucionActivo(long NPK_Motivodevolucion, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarMotivodevolucionActivo(NPK_Motivodevolucion, Activo, NFK_User);
        }

        #endregion
        #region Naviera
        public List<vwNaviera> TraerNavieras(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerNavieras(Activo);
            else
                return repo.TraerNavieras(null);
        }
        public NavieraCatalogo GuardarNaviera(NavieraCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarNaviera(datos, NFK_User);
        }
        public NavieraCatalogo GuardarNavieraActivo(long NPK_Naviera, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarNavieraActivo(NPK_Naviera, Activo, NFK_User);
        }

        #endregion
        #region Paisorigen
        public List<vwPaisOrigen> TraerPaisOrigens(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerPaisOrigens(Activo);
            else
                return repo.TraerPaisOrigens(null);
        }
        public PaisOrigenCatalogo GuardarPaisOrigen(PaisOrigenCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarPaisOrigen(datos, NFK_User);
        }
        public PaisOrigenCatalogo GuardarPaisOrigenActivo(long NPK_PaisOrigen, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarPaisOrigenActivo(NPK_PaisOrigen, Activo, NFK_User);
        }

        #endregion
        #region Producto
        public List<vwProducto> TraerProductos(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerProductos(Activo);
            else
                return repo.TraerProductos(null);
        }
        public ProductoCatalogo GuardarProducto(ProductoCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarProducto(datos, NFK_User);
        }
        public ProductoCatalogo GuardarProductoActivo(long NPK_Producto, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarProductoActivo(NPK_Producto, Activo, NFK_User);
        }

        #endregion
        #region Proveedor
        public List<vwProveedor> TraerProveedors(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerProveedors(Activo);
            else
                return repo.TraerProveedors(null);
        }
        public ProveedorCatalogo GuardarProveedor(ProveedorCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarProveedor(datos, NFK_User);
        }
        public ProveedorCatalogo GuardarProveedorActivo(long NPK_Proveedor, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarProveedorActivo(NPK_Proveedor, Activo, NFK_User);
        }

        #endregion
        #region Servicio
        public List<vwServicio> TraerServicios(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerServicios(Activo);
            else
                return repo.TraerServicios(null);
        }
        public ServicioCatalogo GuardarServicio(ServicioCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarServicio(datos, NFK_User);
        }
        public ServicioCatalogo GuardarServicioActivo(long NPK_Servicio, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarServicioActivo(NPK_Servicio, Activo, NFK_User);
        }

        #endregion
        #region Subcategoria
        public List<vwSubCategoria> TraerSubCategoriass(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerSubcategoriass(Activo);
            else
                return repo.TraerSubcategoriass(null);
        }
        public SubCategoriasCatalogo GuardarSubCategorias(SubCategoriasCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarSubcategorias(datos, NFK_User);
        }
        public SubCategoriasCatalogo GuardarSubCategoriasActivo(long NPK_SubCategorias, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarSubcategoriasActivo(NPK_SubCategorias, Activo, NFK_User);
        }



        #endregion
        #region TipoAcabado        
        public List<vwTipoAcabado> TraerTipoAcabados(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerTipoAcabados(Activo);
            else
                return repo.TraerTipoAcabados(null);
        }
        public TipoAcabadoCatalogo GuardarTipoAcabado(TipoAcabadoCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarTipoAcabado(datos, NFK_User);
        }
        public TipoAcabadoCatalogo GuardarTipoAcabadoActivo(long NPK_TipoAcabado, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarTipoAcabadoActivo(NPK_TipoAcabado, Activo, NFK_User);
        }

        #endregion
        #region TipoComentario
        public List<vwTipoComentario> TraerTipoComentarios(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerTipoComentarios(Activo);
            else
                return repo.TraerTipoComentarios(null);
        }
        public TipoComentarioCatalogo GuardarTipoComentario(TipoComentarioCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarTipoComentario(datos, NFK_User);
        }
        public TipoComentarioCatalogo GuardarTipoComentarioActivo(long NPK_TipoComentario, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarTipoComentarioActivo(NPK_TipoComentario, Activo, NFK_User);
        }

        #endregion
        #region TipoDevolucion
        public List<vwTipoDevolucion> TraerTipoDevolucions(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerTipoDevolucions(Activo);
            else
                return repo.TraerTipoDevolucions(null);
        }
        public TipoDevolucionCatalogo GuardarTipoDevolucion(TipoDevolucionCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarTipoDevolucion(datos, NFK_User);
        }
        public TipoDevolucionCatalogo GuardarTipoDevolucionActivo(long NPK_TipoDevolucion, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarTipoDevolucionActivo(NPK_TipoDevolucion, Activo, NFK_User);
        }

        #endregion
        #region TipoEmbarque
        public List<vwTipoEmbarque> TraerTipoEmbarques(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerTipoEmbarques(Activo);
            else
                return repo.TraerTipoEmbarques(null);
        }
        public TipoEmbarqueCatalogo GuardarTipoEmbarque(TipoEmbarqueCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarTipoEmbarque(datos, NFK_User);
        }
        public TipoEmbarqueCatalogo GuardarTipoEmbarqueActivo(long NPK_TipoEmbarque, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarTipoEmbarqueActivo(NPK_TipoEmbarque, Activo, NFK_User);
        }

        #endregion
        #region TipoMovimientoInventario
        public List<vwTipoMovimientoInventario> TraerTipoMovimientoInventarios(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerTipoMovimientoInventarios(Activo);
            else
                return repo.TraerTipoMovimientoInventarios(null);
        }
        public TipoMovimientoInventarioCatalogo GuardarTipoMovimientoInventario(TipoMovimientoInventarioCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarTipoMovimientoInventario(datos, NFK_User);
        }
        public TipoMovimientoInventarioCatalogo GuardarTipoMovimientoInventarioActivo(long NPK_TipoMovimientoInventario, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarTipoMovimientoInventarioActivo(NPK_TipoMovimientoInventario, Activo, NFK_User);
        }

        #endregion
        #region TipoPago
        public List<vwTipoPago> TraerTipoPagos(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerTipoPagos(Activo);
            else
                return repo.TraerTipoPagos(null);
        }
        public TipoPagoCatalogo GuardarTipoPago(TipoPagoCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarTipoPago(datos, NFK_User);
        }
        public TipoPagoCatalogo GuardarTipoPagoActivo(long NPK_TipoPago, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarTipoPagoActivo(NPK_TipoPago, Activo, NFK_User);
        }

        #endregion
        #region TipoProducto
        public List<vwTipoProducto> TraerTipoProductos(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerTipoProductos(Activo);
            else
                return repo.TraerTipoProductos(null);
        }
        public TipoProductoCatalogo GuardarTipoProducto(TipoProductoCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarTipoProducto(datos, NFK_User);
        }
        public TipoProductoCatalogo GuardarTipoProductoActivo(long NPK_TipoProducto, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarTipoProductoActivo(NPK_TipoProducto, Activo, NFK_User);
        }

        #endregion
        #region TipoProveedor
        public List<vwTipoProveedor> TraerTipoProveedors(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerTipoProveedors(Activo);
            else
                return repo.TraerTipoProveedors(null);
        }
        public TipoProveedorCatalogo GuardarTipoProveedor(TipoProveedorCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarTipoProveedor(datos, NFK_User);
        }
        public TipoProveedorCatalogo GuardarTipoProveedorActivo(long NPK_TipoProveedor, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarTipoProveedorActivo(NPK_TipoProveedor, Activo, NFK_User);
        }

        #endregion
        #region TipoVenta
        public List<vwTipoVenta> TraerTipoVentas(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerTipoVentas(Activo);
            else
                return repo.TraerTipoVentas(null);
        }
        public TipoVentaCatalogo GuardarTipoVenta(TipoVentaCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarTipoVenta(datos, NFK_User);
        }
        public TipoVentaCatalogo GuardarTipoVentaActivo(long NPK_TipoVenta, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarTipoVentaActivo(NPK_TipoVenta, Activo, NFK_User);
        }

        #endregion
        #region Usuario
        public List<vwUsuarioCat> TraerUsuarios(int Activo)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            if (Activo < 2)
                return repo.TraerUsuarios(Activo);
            else
                return repo.TraerUsuarios(null);
        }
        public UsuarioCatalogo GuardarUsuario(UsuarioCatalogo datos, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            datos.Activo = 1;
            return repo.GuardarUsuario(datos, NFK_User);
        }
        public UsuarioCatalogo GuardarUsuarioActivo(long NPK_Usuario, int Activo, int NFK_User)
        {
            var repo = new CatalogRepository(ClientConnectionString);
            return repo.GuardarUsuarioActivo(NPK_Usuario, Activo, NFK_User);
        }

        #endregion
        #region Venta 
        public VentaCatalogo GuardarVenta(VentaCatalogo datos, int NFK_User)
        {
            var repo = new Repositories.CatalogRepository(DymaDieckBackend.Util.DbManager.ConnectionString.Connection);
            datos.Activo = 1;
            return repo.GuardarVenta(datos, NFK_User);

        }
        public List<vwVenta> TraerVentas(int Activo)
        {
            var repo = new Repositories.CatalogRepository(DymaDieckBackend.Util.DbManager.ConnectionString.Connection);
            if (Activo < 2)
                return repo.TraerVentas(Activo);
            else
                return repo.TraerVentas(null);
        }
        #endregion
        #region Ventadetalle 
        public VentadetalleCatalogo GuardarVentadetalle(VentadetalleCatalogo datos, int NFK_User)
        {
            var repo = new Repositories.CatalogRepository(DymaDieckBackend.Util.DbManager.ConnectionString.Connection);
            
            return repo.GuardarVentadetalle(datos, NFK_User);

        }
        public List<vwVentadetalle> TraerVentasdetalle(int NFK_Venta)
        {
            var repo = new Repositories.CatalogRepository(DymaDieckBackend.Util.DbManager.ConnectionString.Connection);
            if (NFK_Venta > 0)
                return repo.TraerVentasdetalle(NFK_Venta);
            else
                return repo.TraerVentasdetalle(null);
        }
        #endregion
        #region Cotizacion 
        public List<vwCotizacion> TraerCotizacion(int Activo)
        {
            var repo = new Repositories.CatalogRepository(DymaDieckBackend.Util.DbManager.ConnectionString.Connection);
            if (Activo < 2)
                return repo.TraerCotizacion(Activo);
            else
                return repo.TraerCotizacion(null);
        }
        #endregion
    }
}
