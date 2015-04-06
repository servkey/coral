using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using WebApplication1.Controllers;

namespace WebApplication1.WebServices
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TableInstance
    {
        // Para usar HTTP GET, agregue el atributo [WebGet]. (El valor predeterminado de ResponseFormat es WebMessageFormat.Json)
        // Para crear una operación que devuelva XML,
        //     agregue [WebGet(ResponseFormat=WebMessageFormat.Xml)]
        //     e incluya la siguiente línea en el cuerpo de la operación:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        
        [OperationContract]
        public bool CreateDatabase(string databaseName)
        {
            Connection cn = new Connection();
            DBM sql = new DBM(cn);
            return sql.createDataBase(databaseName);            
        }
        [OperationContract]
        public int CreateTable(string tableName, string[] colsname, string[] colsvalue)
        {

            // Agregue aquí la implementación de la operación
            Connection cn = new Connection();
            DBM sql = new DBM(cn);            
            return 0;
        }

        // Agregue aquí más operaciones y márquelas con [OperationContract]
    }
}
