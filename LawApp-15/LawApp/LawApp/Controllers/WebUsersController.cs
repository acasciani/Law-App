// Code is generated by Telerik Data Access Service Wizard
// using WebApiController.tt template

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using LawAppModel;

namespace LawApp
{
    /// <summary>
    /// Web API Controller for WebUsers entity defined in LawAppModel.LawApp data model
    /// </summary>
    public partial class WebUsersController : OpenAccessBaseApiController<LawAppModel.WebUser, LawAppModel.LawApp>
    {
        /// <summary>
        /// Constructor used by the Web API infrastructure.
        /// </summary>
        public WebUsersController()
        {
            this.repository = new WebUserRepository();
        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Web API Infrastructure will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public WebUsersController(IOpenAccessBaseRepository<LawAppModel.WebUser , LawAppModel.LawApp> repository)
        {
            this.repository = repository;
        }

        // Get all method is implemented in the base class

        /// <summary>
        /// Gets single instance by it's primary key
        /// </summary>
        /// <param name="id">Primary key value to filter by</param>
        /// <returns>Entity instance if a matching entity is found</returns>
        public virtual LawAppModel.WebUser Get(Int32 id)
        {
            LawAppModel.WebUser entity = repository.GetBy(l => l.WebUserId == id);

            if (entity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return entity;
        }

        
        /// <summary>
        /// Updates single entity.
        /// </summary>
        /// <remarks>Replaces the whole existing entity with the provided one</remarks>
        /// <param name="id">ID of the entity to update</param>
        /// <param name="entity">Entity with the new updated values</param>
        /// <returns>HttpStatusCode.BadRequest if ID parameter does not match the ID value of the entity,
        /// or HttpStatusCode.NoContent if the operation was successful</returns>
        public virtual HttpResponseMessage Put(Int32 id, LawAppModel.WebUser entity)
        {
                        if (entity == null ||
                id != entity.WebUserId)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            repository.Update(entity);

            return Request.CreateResponse(HttpStatusCode.NoContent);
                    }

        /// <summary>
        /// Deletes an entity by it's ID
        /// </summary>
        /// <param name="id">ID of the entity to delete</param>
        /// <returns>Always HttpStatusCode.OK</returns>
        public virtual HttpResponseMessage Delete(Int32 id)
        {
                        LawAppModel.WebUser entity = repository.GetBy(l => l.WebUserId == id);
            if (entity != null)
            {
                repository.Delete(entity);
            }

            // According to the HTTP specification, the DELETE method must be idempotent, 
            // meaning that several DELETE requests to the same URI must have the same effect as a single DELETE request. 
            // Therefore, the method should not return an error code if the product was already deleted.
            return new HttpResponseMessage(HttpStatusCode.OK);
                    }

        /// <summary>
        /// Creates the response sent back to client after a new entity is successfully created.
        /// </summary>
        /// <param name="httpStatusCode">Status code to return</param>
        /// <param name="entityToEmbed">Entity instance to embed in the response</param>
        /// <returns>HttpResponseMessage with the provided status code and object to embed</returns>
        protected override HttpResponseMessage CreateResponse(HttpStatusCode httpStatusCode, LawAppModel.WebUser entityToEmbed)
        {
            HttpResponseMessage response = Request.CreateResponse<LawAppModel.WebUser>(httpStatusCode, entityToEmbed);

            string uri = Url.Link("DefaultApi", new { id = entityToEmbed.WebUserId });
            response.Headers.Location = new Uri(uri);

            return response;
        }
    }
}
