using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace FieldSensorApi.Controllers
{
    using FieldSensorApi.Models;

    using Microsoft.Azure.Documents.Client;

    public class FieldSensorController : ApiController
    {
        private const string EndpointUri = "https://fieldsesnsors-db.documents.azure.com:443/";

        private const string PrimaryKey = "Kz9i02TEV3RhhBNIESXyCt77WUoecTTJWjQtLutlNS1Tugfh00upl0Vua4x8IWF90h7oPcXlUt72nedmNc0dng==";
        private const string DatabaseName = "sensordata";
        private const string CollectionName = "data";

        // GET api/FieldSensor/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get(int id)
        {
            var client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
            FeedOptions queryOptions = new FeedOptions
            {
                MaxItemCount = -1
            };
            // Here we find the Building via its Id/building number
            IQueryable<HumidityRecord> buildingQuery = client.CreateDocumentQuery<HumidityRecord>(UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName), queryOptions).Where(f => f.Id == id.ToString());
            if (buildingQuery != null)
            {
                return Ok(buildingQuery);
            }
            return NotFound();
        }
    }
}