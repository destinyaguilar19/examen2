using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using DymaDieckAPI.Filters;
using DymaDieckBackend.Entity;
using DymaDieckBackend.exceptions;
using DymaDieckBackend.Actions;
using System.IO;
using DymaDieckAPI.Models;
using System.Collections.Specialized;
using System.Web.Hosting;
using System.Web;
using System.Xml.Serialization;
using System.Xml;

namespace DymaDieckAPI.Controllers
{
    /// <summary>
    /// Controlador de todos los catalogos que existen en el sistema, requiere previa autorizacion.
    /// </summary>
    [EnableCors("*", "*", "GET,POST,PUT,DELETE, OPTIONS")]
    [RoutePrefix("api/v1/catalog")]
    public class CatalogController : BaseController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

       
        #region Empresa
        [JwtAuthentication]
        [Route("Empresa/{activo:int}"), HttpGet, ResponseType(typeof(List<vwEmpresa>))]
        public HttpResponseMessage TraerEmpresas(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerEmpresas(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Empresa"), HttpPost, ResponseType(typeof(Models.EmpresaForm))]
        public HttpResponseMessage GuardarEmpresa(Models.EmpresaForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new EmpresaCatalogo()
                {
                    NPK_Empresa = datos.NPK_Empresa,
                    NombreEmpresa = datos.NombreEmpresa,
                    RazonSocial = datos.RazonSocial,
                    Calle = datos.Calle,
                    NumeroExterior = datos.NumeroExterior,
                    NumeroInterior = datos.NumeroInterior,
                    Colonia = datos.Colonia,
                    Ciudad = datos.Ciudad,
                    Estado = datos.Estado,
                    CodigoPostal = datos.CodigoPostal,
                    RFC = datos.RFC,
                    CURP = datos.CURP
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarEmpresa(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Empresa/{NPK_Empresa:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.EmpresaForm))]
        public HttpResponseMessage UpdateActivateEmpresa(long NPK_Empresa, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarEmpresaActivo(NPK_Empresa, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region TipoEmpleado
        [JwtAuthentication]
        [Route("TipoEmpleado/{activo:int}"), HttpGet, ResponseType(typeof(List<vwTipoEmpleado>))]
        public HttpResponseMessage TraerTipoEmpleados(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerTipoEmpleados(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoEmpleado"), HttpPost, ResponseType(typeof(Models.TipoEmpleadoForm))]
        public HttpResponseMessage GuardarTipoEmpleado(Models.TipoEmpleadoForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new TipoEmpleadoCatalogo()
                {
                    NPK_TipoEmpleado = datos.NPK_TipoEmpleado,
                    TipoEmpleado = datos.TipoEmpleado
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoEmpleado(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoEmpleado/{NPK_TipoEmpleado:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.TipoEmpleadoForm))]
        public HttpResponseMessage UpdateActivateTipoEmpleado(long NPK_TipoEmpleado, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoEmpleadoActivo(NPK_TipoEmpleado, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Empleado
        [JwtAuthentication]
        [Route("Empleado/{activo:int}"), HttpGet, ResponseType(typeof(List<vwEmpleado>))]
        public HttpResponseMessage TraerEmpleados(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerEmpleados(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Empleado"), HttpPost, ResponseType(typeof(Models.EmpleadoForm))]
        public HttpResponseMessage GuardarEmpleado(Models.EmpleadoForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new EmpleadoCatalogo()
                {
                    NPK_Empleado = datos.NPK_Empleado,
                    NFK_Empresa = datos.NFK_Empresa,
                    Nombres = datos.Nombres,
                    ApellidoPaterno = datos.ApellidoPaterno,
                    ApellidoMaterno = datos.ApellidoMaterno,
                    FechaNacimiento = datos.FechaNacimiento,
                    FechaIngresoDieck = datos.FechaIngresoDieck,
                    NFK_TipoEmpleado = datos.NFK_TipoEmpleado,
                    Curp = datos.Curp,
                    NumeroIMSS = datos.NumeroIMSS,
                    RFC = datos.RFC
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarEmpleado(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Empleado/{NPK_Empleado:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.EmpleadoForm))]
        public HttpResponseMessage UpdateActivateEmpleado(long NPK_Empleado, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarEmpleadoActivo(NPK_Empleado, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Instalador
        [JwtAuthentication]
        [Route("Instalador/{activo:int}"), HttpGet, ResponseType(typeof(List<vwInstalador>))]
        public HttpResponseMessage TraerInstaladors(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerInstaladors(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Instalador"), HttpPost, ResponseType(typeof(Models.InstaladorForm))]
        public HttpResponseMessage GuardarInstalador(Models.InstaladorForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new InstaladorCatalogo()
                {
                    NPK_Instalador = datos.NPK_Instalador,
                    Nombres = datos.Nombres,
                    ApellidoPaterno = datos.ApellidoPaterno,
                    ApellidoMaterno = datos.ApellidoMaterno,
                    Direccion = datos.Direccion,
                    RFC = datos.RFC,
                    Telefonos = datos.Telefonos,
                    NFK_Empresa = datos.NFK_Empresa,
                    FechaNacimiento = datos.FechaNacimiento,
                    NumeroIMSS = datos.NumeroIMSS
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarInstalador(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Instalador/{NPK_Instalador:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.InstaladorForm))]
        public HttpResponseMessage UpdateActivateInstalador(long NPK_Instalador, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarInstaladorActivo(NPK_Instalador, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region RegistroIMSS
        [JwtAuthentication]
        [Route("RegistroIMSS/{activo:int}"), HttpGet, ResponseType(typeof(List<vwRegistroIMSS>))]
        public HttpResponseMessage TraerRegistroIMSSs(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerRegistroIMSSs(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("RegistroIMSS"), HttpPost, ResponseType(typeof(Models.RegistroIMSSForm))]
        public HttpResponseMessage GuardarRegistroIMSS(Models.RegistroIMSSForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new RegistroIMSSCatalogo()
                {
                    NPK_Registro_IMSS = datos.NPK_Registro_IMSS,
                    Registro_IMSS = datos.Registro_IMSS,
                    NFK_Empleado = datos.NFK_Empleado,
                    NFK_Instalador = datos.NFK_Instalador,
                    NFK_Empresa = datos.NFK_Empresa,
                    Fecha_Inicio = datos.Fecha_Inicio,
                    Fecha_Fin_Periodo = datos.Fecha_Fin_Periodo,
                    Comentarios = datos.Comentarios,
                    Salario = datos.Salario
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarRegistroIMSS(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("RegistroIMSS/{NPK_RegistroIMSS:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.RegistroIMSSForm))]
        public HttpResponseMessage UpdateActivateRegistroIMSS(long NPK_RegistroIMSS, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarRegistroIMSSActivo(NPK_RegistroIMSS, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Material
        [JwtAuthentication]
        [Route("Material/{activo:int}"), HttpGet, ResponseType(typeof(List<vwMaterial>))]
        public HttpResponseMessage TraerMaterials(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerMaterials(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Material"), HttpPost, ResponseType(typeof(Models.MaterialForm))]
        public HttpResponseMessage GuardarMaterial(Models.MaterialForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new MaterialCatalogo()
                {
                    NPK_Material = datos.NPK_Material,
                    Material = datos.Material,
                    Precio = datos.Precio,
                    NFK_UnidadMedida = datos.NFK_UnidadMedida
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarMaterial(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Material/{NPK_Material:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.MaterialForm))]
        public HttpResponseMessage UpdateActivateMaterial(long NPK_Material, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarMaterialActivo(NPK_Material, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region UnidadMedida
        [JwtAuthentication]
        [Route("UnidadMedida/{activo:int}"), HttpGet, ResponseType(typeof(List<vwUnidadMedida>))]
        public HttpResponseMessage TraerUnidadMedidas(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerUnidadMedidas(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("UnidadMedida"), HttpPost, ResponseType(typeof(Models.UnidadMedidaForm))]
        public HttpResponseMessage GuardarUnidadMedida(Models.UnidadMedidaForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new UnidadMedidaCatalogo()
                {
                    NPK_UnidadMedida = datos.NPK_UnidadMedida,
                    UnidadMedida = datos.UnidadMedida,
                    CveUnidadMedida = datos.CveUnidadMedida,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarUnidadMedida(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("UnidadMedida/{NPK_UnidadMedida:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.UnidadMedidaForm))]
        public HttpResponseMessage UpdateActivateUnidadMedida(long NPK_UnidadMedida, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarUnidadMedidaActivo(NPK_UnidadMedida, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Categoria
        [JwtAuthentication]
        [Route("Categorias/{activo:int}"), HttpGet, ResponseType(typeof(List<vwCategorias>))]
        public HttpResponseMessage TraerCategoriass(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerCategoriass(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Categorias"), HttpPost, ResponseType(typeof(Models.CategoriasForm))]
        public HttpResponseMessage GuardarCategorias(Models.CategoriasForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new CategoriasCatalogo()
                {
                    NPK_Categoria = datos.NPK_Categoria,
                    Categoria = datos.Categoria,
                    CveCategoria = datos.CveCategoria,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarCategorias(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Categorias/{NPK_Categorias:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.CategoriasForm))]
        public HttpResponseMessage UpdateActivateCategorias(long NPK_Categorias, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarCategoriasActivo(NPK_Categorias, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region espesor
        [JwtAuthentication]
        [Route("Espesor/{activo:int}"), HttpGet, ResponseType(typeof(List<vwEspesor>))]
        public HttpResponseMessage TraerEspesors(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerEspesors(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Espesor"), HttpPost, ResponseType(typeof(Models.EspesorForm))]
        public HttpResponseMessage GuardarEspesor(Models.EspesorForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new EspesorCatalogo()
                {
                    NPK_Espesor = datos.NPK_Espesor,
                    Espesor = datos.Espesor,
                    CveEspesor = datos.CveEspesor,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarEspesor(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Espesor/{NPK_Espesor:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.EspesorForm))]
        public HttpResponseMessage UpdateActivateEspesor(long NPK_Espesor, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarEspesorActivo(NPK_Espesor, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Formapago
        [JwtAuthentication]
        [Route("Formapago/{activo:int}"), HttpGet, ResponseType(typeof(List<vwFormapago>))]
        public HttpResponseMessage TraerFormapagos(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerFormapagos(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Formapago"), HttpPost, ResponseType(typeof(Models.FormapagoForm))]
        public HttpResponseMessage GuardarFormapago(Models.FormapagoForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new FormapagoCatalogo()
                {
                    NPK_FormaPago = datos.NPK_FormaPago,
                    FormaPago = datos.FormaPago,
                    CveFormaPago = datos.CveFormaPago,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarFormapago(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Formapago/{NPK_Formapago:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.FormapagoForm))]
        public HttpResponseMessage UpdateActivateFormapago(long NPK_Formapago, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarFormapagoActivo(NPK_Formapago, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Cliente
        [JwtAuthentication]
        [Route("Cliente/{activo:int}"), HttpGet, ResponseType(typeof(List<vwCliente>))]
        public HttpResponseMessage TraerClientes(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerClientes(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Cliente"), HttpPost, ResponseType(typeof(Models.ClienteForm))]
        public HttpResponseMessage GuardarCliente(Models.ClienteForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new ClienteCatalogo()
                {
                    NPK_Cliente = datos.NPK_Cliente,
                    NombreCorto = datos.NombreCorto,
                    NombreCliente = datos.NombreCliente,
                    CveCliente = datos.CveCliente,
                    Calle = datos.Calle,
                    NumeroExterior = datos.NumeroExterior,
                    NumeroInterior = datos.NumeroInterior,
                    Colonia = datos.Colonia,
                    Ciudad = datos.Ciudad,
                    CodigoPostal = datos.CodigoPostal,
                    Estado = datos.Estado,
                    SitioWeb = datos.SitioWeb,
                    Nombres = datos.Nombres,
                    Apellidos = datos.Apellidos,
                    TipoPersona = datos.TipoPersona,
                    ApellidoPaterno = datos.ApellidoPaterno,
                    ApellidoMaterno = datos.ApellidoMaterno,
                    Entrecalles = datos.Entrecalles,
                    TelefonoCasa = datos.TelefonoCasa,
                    TelefonoNegocio = datos.TelefonoNegocio,
                    TelefonoNegocio1 = datos.TelefonoNegocio1,
                    TelefonoCelular = datos.TelefonoCelular,
                    Fax = datos.Fax,
                    Email = datos.Email,
                    Email2 = datos.Email2,
                    Contacto = datos.Contacto
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarCliente(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Cliente/{NPK_Cliente:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.ClienteForm))]
        public HttpResponseMessage UpdateActivateCliente(long NPK_Cliente, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarClienteActivo(NPK_Cliente, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Fleteroterrestre
        [JwtAuthentication]
        [Route("Fleteroterrestre/{activo:int}"), HttpGet, ResponseType(typeof(List<vwFleteroterrestre>))]
        public HttpResponseMessage TraerFleteroterrestres(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerFleteroterrestres(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Fleteroterrestre"), HttpPost, ResponseType(typeof(Models.FleteroterrestreForm))]
        public HttpResponseMessage GuardarFleteroterrestre(Models.FleteroterrestreForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new FleteroterrestreCatalogo()
                {
                    NPK_FleteroTerrestre = datos.NPK_FleteroTerrestre,
                    FleteroTerrestre = datos.FleteroTerrestre,
                    Direccion = datos.Direccion,
                    Telefonos = datos.Telefonos,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarFleteroterrestre(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Fleteroterrestre/{NPK_Fleteroterrestre:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.FleteroterrestreForm))]
        public HttpResponseMessage UpdateActivateFleteroterrestre(long NPK_Fleteroterrestre, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarFleteroterrestreActivo(NPK_Fleteroterrestre, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Forwarder
        [JwtAuthentication]
        [Route("Forwarder/{activo:int}"), HttpGet, ResponseType(typeof(List<vwForwarder>))]
        public HttpResponseMessage TraerForwarders(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerForwarders(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Forwarder"), HttpPost, ResponseType(typeof(Models.ForwarderForm))]
        public HttpResponseMessage GuardarForwarder(Models.ForwarderForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new ForwarderCatalogo()
                {
                    NPK_Forwarder = datos.NPK_Forwarder,
                    Forwarder = datos.Forwarder,
                    Direccion = datos.Direccion,
                    Telefonos = datos.Telefonos,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarForwarder(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Forwarder/{NPK_Forwarder:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.ForwarderForm))]
        public HttpResponseMessage UpdateActivateForwarder(long NPK_Forwarder, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarForwarderActivo(NPK_Forwarder, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Herramienta
        [JwtAuthentication]
        [Route("Herramienta/{activo:int}"), HttpGet, ResponseType(typeof(List<vwHerramienta>))]
        public HttpResponseMessage TraerHerramientas(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerHerramientas(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Herramienta"), HttpPost, ResponseType(typeof(Models.HerramientaForm))]
        public HttpResponseMessage GuardarHerramienta(Models.HerramientaForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new HerramientaCatalogo()
                {
                    NPK_Herramienta = datos.NPK_Herramienta,
                    Herramienta = datos.Herramienta,
                    Marca = datos.Marca,
                    Modelo = datos.Modelo,
                    Precio = datos.Precio
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarHerramienta(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Herramienta/{NPK_Herramienta:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.HerramientaForm))]
        public HttpResponseMessage UpdateActivateHerramienta(long NPK_Herramienta, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarHerramientaActivo(NPK_Herramienta, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Iva
        [JwtAuthentication]
        [Route("Iva/{activo:int}"), HttpGet, ResponseType(typeof(List<vwIva>))]
        public HttpResponseMessage TraerIvas(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerIvas(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Iva"), HttpPost, ResponseType(typeof(Models.IvaForm))]
        public HttpResponseMessage GuardarIva(Models.IvaForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new IvaCatalogo()
                {
                    NPK_Iva = datos.NPK_IVA,
                    IVA = datos.IVA,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa,
                    PorcentajeAgregar = datos.PorcentajeAgregar
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarIva(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Iva/{NPK_Iva:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.IvaForm))]
        public HttpResponseMessage UpdateActivateIva(long NPK_Iva, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarIvaActivo(NPK_Iva, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        #endregion
        #region Medida
        [JwtAuthentication]
        [Route("Medida/{activo:int}"), HttpGet, ResponseType(typeof(List<vwMedida>))]
        public HttpResponseMessage TraerMedidas(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerMedidas(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Medida"), HttpPost, ResponseType(typeof(Models.MedidaForm))]
        public HttpResponseMessage GuardarMedida(Models.MedidaForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new MedidaCatalogo()
                {
                    NPK_Medida = datos.NPK_Medida,
                    Medida = datos.Medida,
                    CveMedida = datos.CveMedida,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarMedida(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Medida/{NPK_Medida:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.MedidaForm))]
        public HttpResponseMessage UpdateActivateMedida(long NPK_Medida, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarMedidaActivo(NPK_Medida, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Moneda
        [JwtAuthentication]
        [Route("Moneda/{activo:int}"), HttpGet, ResponseType(typeof(List<vwMoneda>))]
        public HttpResponseMessage TraerMonedas(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerMonedas(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Moneda"), HttpPost, ResponseType(typeof(Models.MonedaForm))]
        public HttpResponseMessage GuardarMoneda(Models.MonedaForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new MonedaCatalogo()
                {
                    NPK_Moneda = datos.NPK_Moneda,
                    Moneda = datos.Moneda,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarMoneda(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Moneda/{NPK_Moneda:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.MonedaForm))]
        public HttpResponseMessage UpdateActivateMoneda(long NPK_Moneda, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarMonedaActivo(NPK_Moneda, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion
        #region Motivodevolucion
        [JwtAuthentication]
        [Route("Motivodevolucion/{activo:int}"), HttpGet, ResponseType(typeof(List<vwMotivodevolucion>))]
        public HttpResponseMessage TraerMotivodevolucions(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerMotivodevolucions(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Motivodevolucion"), HttpPost, ResponseType(typeof(Models.MotivodevolucionForm))]
        public HttpResponseMessage GuardarMotivodevolucion(Models.MotivodevolucionForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new MotivodevolucionCatalogo()
                {
                    NPK_MotivoDevolucion = datos.NPK_MotivoDevolucion,
                    MotivoDevolucion = datos.MotivoDevolucion,
                    CveMotivoDevolucion = datos.CveMotivoDevolucion,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarMotivodevolucion(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Motivodevolucion/{NPK_Motivodevolucion:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.MotivodevolucionForm))]
        public HttpResponseMessage UpdateActivateMotivodevolucion(long NPK_Motivodevolucion, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarMotivodevolucionActivo(NPK_Motivodevolucion, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Naviera
        [JwtAuthentication]
        [Route("Naviera/{activo:int}"), HttpGet, ResponseType(typeof(List<vwNaviera>))]
        public HttpResponseMessage TraerNavieras(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerNavieras(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Naviera"), HttpPost, ResponseType(typeof(Models.NavieraForm))]
        public HttpResponseMessage GuardarNaviera(Models.NavieraForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new NavieraCatalogo()
                {
                    NPK_Naviera = datos.NPK_Naviera,
                    Naviera = datos.Naviera,
                    Direccion = datos.Direccion,
                    Telefonos = datos.Telefonos,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarNaviera(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Naviera/{NPK_Naviera:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.NavieraForm))]
        public HttpResponseMessage UpdateActivateNaviera(long NPK_Naviera, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarNavieraActivo(NPK_Naviera, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Paisorigen
        [JwtAuthentication]
        [Route("PaisOrigen/{activo:int}"), HttpGet, ResponseType(typeof(List<vwPaisOrigen>))]
        public HttpResponseMessage TraerPaisOrigens(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerPaisOrigens(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("PaisOrigen"), HttpPost, ResponseType(typeof(Models.PaisOrigenForm))]
        public HttpResponseMessage GuardarPaisOrigen(Models.PaisOrigenForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new PaisOrigenCatalogo()
                {
                    NPK_PaisOrigen = datos.NPK_PaisOrigen,
                    PaisOrigen = datos.PaisOrigen,
                    CvePais = datos.CvePais,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarPaisOrigen(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("PaisOrigen/{NPK_PaisOrigen:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.PaisOrigenForm))]
        public HttpResponseMessage UpdateActivatePaisOrigen(long NPK_PaisOrigen, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarPaisOrigenActivo(NPK_PaisOrigen, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Producto
        [JwtAuthentication]
        [Route("Producto/{activo:int}"), HttpGet, ResponseType(typeof(List<vwProducto>))]
        public HttpResponseMessage TraerProductos(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerProductos(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Producto"), HttpPost, ResponseType(typeof(Models.ProductoForm))]
        public HttpResponseMessage GuardarProducto(Models.ProductoForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new ProductoCatalogo()
                {
                    NPK_Producto = datos.NPK_Producto,
                    NombreMaterialDieck = datos.NombreMaterialDieck,
                    Nombrecompetencia = datos.Nombrecompetencia,
                    Nombreoriginal = datos.Nombreoriginal,
                    NFK_Categoria = datos.NFK_Categoria,
                    NFK_SubCategoria = datos.NFK_SubCategoria,
                    NFK_TipoAcabado = datos.NFK_TipoAcabado,
                    NFK_PaisOrigen = datos.NFK_PaisOrigen,
                    NFK_Medida = datos.NFK_Medida,
                    NFK_Espesor = datos.NFK_Espesor,
                    NFK_UnidadMedida = datos.NFK_UnidadMedida,
                    NFK_Empresa = datos.NFK_Empresa,
                    ParametrosPlaca = datos.ParametrosPlaca,
                    CveCodigoBarra = datos.CveCodigoBarra,
                    Color = datos.Color,
                    Estatus = datos.Estatus,
                    NFK_Moneda = datos.NFK_Moneda
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarProducto(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Producto/{NPK_Producto:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.ProductoForm))]
        public HttpResponseMessage UpdateActivateProducto(long NPK_Producto, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarProductoActivo(NPK_Producto, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Proveedor
        [JwtAuthentication]
        [Route("Proveedor/{activo:int}"), HttpGet, ResponseType(typeof(List<vwProveedor>))]
        public HttpResponseMessage TraerProveedors(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerProveedors(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Proveedor"), HttpPost, ResponseType(typeof(Models.ProveedorForm))]
        public HttpResponseMessage GuardarProveedor(Models.ProveedorForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new ProveedorCatalogo()
                {
                    NPK_Proveedor = datos.NPK_Proveedor,
                    NombreProveedor = datos.NombreProveedor,
                    Direccion = datos.Direccion,
                    Telefonos = datos.Telefonos,
                    NFK_PaisOrigen = datos.NFK_PaisOrigen,
                    NFK_Empresa = datos.NFK_Empresa,
                    CveCodigoBarra = datos.CveCodigoBarra
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarProveedor(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Proveedor/{NPK_Proveedor:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.ProveedorForm))]
        public HttpResponseMessage UpdateActivateProveedor(long NPK_Proveedor, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarProveedorActivo(NPK_Proveedor, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Servicio

        [JwtAuthentication]
        [Route("Servicio/{activo:int}"), HttpGet, ResponseType(typeof(List<vwServicio>))]
        public HttpResponseMessage TraerServicios(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerServicios(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Servicio"), HttpPost, ResponseType(typeof(Models.ServicioForm))]
        public HttpResponseMessage GuardarServicio(Models.ServicioForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new ServicioCatalogo()
                {
                    NPK_Servicio = datos.NPK_Servicio,
                    Servicio = datos.Servicio,
                    Descripcion = datos.Descripcion,
                    TipoMedida = datos.TipoMedida,
                    NFK_Moneda = datos.NFK_Moneda
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarServicio(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Servicio/{NPK_Servicio:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.ServicioForm))]
        public HttpResponseMessage UpdateActivateServicio(long NPK_Servicio, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarServicioActivo(NPK_Servicio, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Subcategoria
        [JwtAuthentication]
        [Route("SubCategorias/{activo:int}"), HttpGet, ResponseType(typeof(List<vwSubCategoria>))]
        public HttpResponseMessage TraerSubCategoriass(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerSubCategoriass(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("SubCategorias"), HttpPost, ResponseType(typeof(Models.SubCategoriasForm))]
        public HttpResponseMessage GuardarSubCategorias(Models.SubCategoriasForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new SubCategoriasCatalogo()
                {
                    NPK_SubCategoria = datos.NPK_SubCategoria,
                    NFK_Categoria = datos.NFK_Categoria,
                    SubCategoria = datos.SubCategoria,
                    CveSubCategoria = datos.CveSubCategoria,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarSubCategorias(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("SubCategorias/{NPK_SubCategorias:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.SubCategoriasForm))]
        public HttpResponseMessage UpdateActivateSubCategorias(long NPK_SubCategorias, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarSubCategoriasActivo(NPK_SubCategorias, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region TipoAcabado
        [JwtAuthentication]
        [Route("TipoAcabado/{activo:int}"), HttpGet, ResponseType(typeof(List<vwTipoAcabado>))]
        public HttpResponseMessage TraerTipoAcabados(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerTipoAcabados(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoAcabado"), HttpPost, ResponseType(typeof(Models.TipoAcabadoForm))]
        public HttpResponseMessage GuardarTipoAcabado(Models.TipoAcabadoForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new TipoAcabadoCatalogo()
                {
                    NPK_TipoAcabado = datos.NPK_TipoAcabado,
                    TipoAcabado = datos.TipoAcabado,
                    CveTipoAcabado = datos.CveTipoAcabado,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoAcabado(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoAcabado/{NPK_TipoAcabado:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.TipoAcabadoForm))]
        public HttpResponseMessage UpdateActivateTipoAcabado(long NPK_TipoAcabado, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoAcabadoActivo(NPK_TipoAcabado, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        #endregion
        #region TipoComentario
        [JwtAuthentication]
        [Route("TipoComentario/{activo:int}"), HttpGet, ResponseType(typeof(List<vwTipoComentario>))]
        public HttpResponseMessage TraerTipoComentarios(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerTipoComentarios(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoComentario"), HttpPost, ResponseType(typeof(Models.TipoComentarioForm))]
        public HttpResponseMessage GuardarTipoComentario(Models.TipoComentarioForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new TipoComentarioCatalogo()
                {
                    NPK_TipoComentario = datos.NPK_TipoComentario,
                    TipoComentario = datos.TipoComentario,
                    CveTipoComentario = datos.CveTipoComentario,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoComentario(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoComentario/{NPK_TipoComentario:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.TipoComentarioForm))]
        public HttpResponseMessage UpdateActivateTipoComentario(long NPK_TipoComentario, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoComentarioActivo(NPK_TipoComentario, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region TipoDevolucion
        [JwtAuthentication]
        [Route("TipoDevolucion/{activo:int}"), HttpGet, ResponseType(typeof(List<vwTipoDevolucion>))]
        public HttpResponseMessage TraerTipoDevolucions(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerTipoDevolucions(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoDevolucion"), HttpPost, ResponseType(typeof(Models.TipoDevolucionForm))]
        public HttpResponseMessage GuardarTipoDevolucion(Models.TipoDevolucionForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new TipoDevolucionCatalogo()
                {
                    NPK_TipoDevolucion = datos.NPK_TipoDevolucion,
                    TipoDevolucion = datos.TipoDevolucion,
                    CveTipoDevolucion = datos.CveTipoDevolucion,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoDevolucion(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoDevolucion/{NPK_TipoDevolucion:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.TipoDevolucionForm))]
        public HttpResponseMessage UpdateActivateTipoDevolucion(long NPK_TipoDevolucion, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoDevolucionActivo(NPK_TipoDevolucion, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region TipoEmbarque
        [JwtAuthentication]
        [Route("TipoEmbarque/{activo:int}"), HttpGet, ResponseType(typeof(List<vwTipoEmbarque>))]
        public HttpResponseMessage TraerTipoEmbarques(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerTipoEmbarques(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoEmbarque"), HttpPost, ResponseType(typeof(Models.TipoEmbarqueForm))]
        public HttpResponseMessage GuardarTipoEmbarque(Models.TipoEmbarqueForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new TipoEmbarqueCatalogo()
                {
                    NPK_TipoEmbarque = datos.NPK_TipoEmbarque,
                    TipoEmbarque = datos.TipoEmbarque,
                    CveTipoEmbarque = datos.CveTipoEmbarque,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoEmbarque(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoEmbarque/{NPK_TipoEmbarque:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.TipoEmbarqueForm))]
        public HttpResponseMessage UpdateActivateTipoEmbarque(long NPK_TipoEmbarque, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoEmbarqueActivo(NPK_TipoEmbarque, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region TipoMovimientoInventario
        [JwtAuthentication]
        [Route("TipoMovimientoInventario/{activo:int}"), HttpGet, ResponseType(typeof(List<vwTipoMovimientoInventario>))]
        public HttpResponseMessage TraerTipoMovimientoInventarios(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerTipoMovimientoInventarios(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoMovimientoInventario"), HttpPost, ResponseType(typeof(Models.TipoMovimientoInventarioForm))]
        public HttpResponseMessage GuardarTipoMovimientoInventario(Models.TipoMovimientoInventarioForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new TipoMovimientoInventarioCatalogo()
                {
                    NPK_TipoMovimientoInventario = datos.NPK_TipoMovimientoInventario,
                    TipoMovimiento = datos.TipoMovimiento,
                    Tipo = datos.Tipo
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoMovimientoInventario(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoMovimientoInventario/{NPK_TipoMovimientoInventario:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.TipoMovimientoInventarioForm))]
        public HttpResponseMessage UpdateActivateTipoMovimientoInventario(long NPK_TipoMovimientoInventario, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoMovimientoInventarioActivo(NPK_TipoMovimientoInventario, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region TipoPago
        [JwtAuthentication]
        [Route("TipoPago/{activo:int}"), HttpGet, ResponseType(typeof(List<vwTipoPago>))]
        public HttpResponseMessage TraerTipoPagos(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerTipoPagos(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoPago"), HttpPost, ResponseType(typeof(Models.TipoPagoForm))]
        public HttpResponseMessage GuardarTipoPago(Models.TipoPagoForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new TipoPagoCatalogo()
                {
                    NPK_TipoPago = datos.NPK_TipoPago,
                    TipoPago = datos.TipoPago,
                    Descripcion = datos.Descripcion
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoPago(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoPago/{NPK_TipoPago:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.TipoPagoForm))]
        public HttpResponseMessage UpdateActivateTipoPago(long NPK_TipoPago, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoPagoActivo(NPK_TipoPago, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region TipoProducto
        [JwtAuthentication]
        [Route("TipoProducto/{activo:int}"), HttpGet, ResponseType(typeof(List<vwTipoProducto>))]
        public HttpResponseMessage TraerTipoProductos(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerTipoProductos(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoProducto"), HttpPost, ResponseType(typeof(Models.TipoProductoForm))]
        public HttpResponseMessage GuardarTipoProducto(Models.TipoProductoForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new TipoProductoCatalogo()
                {
                    NPK_TipoProducto = datos.NPK_TipoProducto,
                    TipoProducto = datos.TipoProducto,
                    CveTipoProducto = datos.CveTipoProducto,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoProducto(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoProducto/{NPK_TipoProducto:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.TipoProductoForm))]
        public HttpResponseMessage UpdateActivateTipoProducto(long NPK_TipoProducto, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoProductoActivo(NPK_TipoProducto, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region TipoProveedor
        [JwtAuthentication]
        [Route("TipoProveedor/{activo:int}"), HttpGet, ResponseType(typeof(List<vwTipoProveedor>))]
        public HttpResponseMessage TraerTipoProveedors(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerTipoProveedors(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoProveedor"), HttpPost, ResponseType(typeof(Models.TipoProveedorForm))]
        public HttpResponseMessage GuardarTipoProveedor(Models.TipoProveedorForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new TipoProveedorCatalogo()
                {
                    NPK_TipoProveedor = datos.NPK_TipoProveedor,
                    TipoProveedor = datos.TipoProveedor,
                    CveTipoProveedor = datos.CveTipoProveedor,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoProveedor(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoProveedor/{NPK_TipoProveedor:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.TipoProveedorForm))]
        public HttpResponseMessage UpdateActivateTipoProveedor(long NPK_TipoProveedor, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoProveedorActivo(NPK_TipoProveedor, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region TipoVenta
        [JwtAuthentication]
        [Route("TipoVenta/{activo:int}"), HttpGet, ResponseType(typeof(List<vwTipoVenta>))]
        public HttpResponseMessage TraerTipoVentas(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerTipoVentas(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoVenta"), HttpPost, ResponseType(typeof(Models.TipoVentaForm))]
        public HttpResponseMessage GuardarTipoVenta(Models.TipoVentaForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new TipoVentaCatalogo()
                {
                    NPK_TipoVenta = datos.NPK_TipoVenta,
                    TipoVenta = datos.TipoVenta,
                    CveTipoVenta = datos.CveTipoVenta,
                    Descripcion = datos.Descripcion,
                    NFK_Empresa = datos.NFK_Empresa
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoVenta(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("TipoVenta/{NPK_TipoVenta:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.TipoVentaForm))]
        public HttpResponseMessage UpdateActivateTipoVenta(long NPK_TipoVenta, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarTipoVentaActivo(NPK_TipoVenta, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Usuario
        [JwtAuthentication]
        [Route("Usuario/{activo:int}"), HttpGet, ResponseType(typeof(List<vwUsuarioCat>))]
        public HttpResponseMessage TraerUsuarios(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerUsuarios(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Usuario"), HttpPost, ResponseType(typeof(Models.UsuarioForm))]
        public HttpResponseMessage GuardarUsuario(Models.UsuarioForm datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new UsuarioCatalogo()
                {
                    NPK_Usuario = datos.NPK_Usuario,
                    Nombre = datos.Nombre,
                    ApellidoPaterno = datos.ApellidoPaterno,
                    ApellidoMaterno = datos.ApellidoMaterno,
                    Usuario = datos.Usuario,
                    contraseña = datos.contraseña,
                    Administrador = datos.Administrador,
                    Vendedor = datos.Vendedor,
                    Almacen = datos.Almacen,
                    TipoUsuario = datos.TipoUsuario
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarUsuario(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Usuario/{NPK_Usuario:long}/{Activo:int}/Activar"), HttpPost, ResponseType(typeof(Models.UsuarioForm))]
        public HttpResponseMessage UpdateActivateUsuario(long NPK_Usuario, int Activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarUsuarioActivo(NPK_Usuario, Activo, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Venta 
        [JwtAuthentication]
        [Route("Venta"), HttpPost, ResponseType(typeof(Models.Ventaform))]
        public HttpResponseMessage GuardarVenta(Models.Ventaform datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new VentaCatalogo()
                {
                    NPK_Venta = datos.NPK_Venta,
                    NFK_Cliente = datos.NFK_Cliente,
                    FechaVenta = datos.FechaVenta,
                    FolioVenta = datos.NPK_Venta,
                    NFK_Empresa = datos.NFK_Empresa,
                    Estatus = "Abierto",
                    Proyecto = datos.Proyecto,
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarVenta(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Venta/{activo:int}"), HttpGet, ResponseType(typeof(List<vwVenta>))]
        public HttpResponseMessage TraerVentas(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerVentas(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion
        #region Ventadetalle
        [JwtAuthentication]
        [Route("Ventadetalle"), HttpPost, ResponseType(typeof(Models.Ventadetalleform))]
        public HttpResponseMessage GuardarVentadetalle(Models.Ventadetalleform datos)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                var resp = new VentadetalleCatalogo()
                {
                    NPK_VentaDetalle = datos.NPK_VentaDetalle,
                    NFK_Venta = datos.NFK_Venta,
                    Cantidad = datos.Cantidad,
                    NFK_UnidadMedida = datos.NFK_UnidadMedida,
                    NFK_Producto=datos.NFK_Producto,
                    PrecioUnitario = datos.PrecioUnitario,
                    NFK_Moneda = datos.NFK_Moneda,
                    NFK_Iva= datos.NFK_Iva,
                    EntregadoAlmacen=datos.EntregadoAlmacen,
                    Factura=datos.Factura,
                    AvanceObra=datos.AvanceObra,
                    NFK_Anticipo=datos.NFK_Anticipo,
                    Esdevolucion=datos.Esdevolucion,

                    
                };

                return Request.CreateResponse(HttpStatusCode.OK, proxy.GuardarVentadetalle(resp, this.GetNpkUser()));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [JwtAuthentication]
        [Route("Ventadetalle/{NFK_Venta:int}"), HttpGet, ResponseType(typeof(List<vwVentadetalle>))]
        public HttpResponseMessage TraerVentasdetalle(int NFK_Venta)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerVentasdetalle(NFK_Venta));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
        #region Cotizacion
        [JwtAuthentication]
        [Route("Cotizacion/{activo:int}"), HttpGet, ResponseType(typeof(List<vwCotizacion>))]
        public HttpResponseMessage TraerCotizacion(int activo)
        {
            try
            {
                var proxy = new Task(this.GetConnectionString());
                return Request.CreateResponse(HttpStatusCode.OK, proxy.TraerCotizacion(activo));
            }
            catch (BusinessRuleValidationException ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var httpError = new HttpError(ex, true);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
    }
}