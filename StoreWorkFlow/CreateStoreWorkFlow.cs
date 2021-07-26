using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace StoreWorkFlow
{
    public class CreateStoreWorkFlow : CodeActivity
    {

        [RequiredArgument]
        [Input("Warehouse Name")]
        public InArgument<string> StoreName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var tracer = context.GetExtension<ITracingService>();
            var factory = context.GetExtension<IOrganizationServiceFactory>();
            var workflowContext = context.GetExtension<IWorkflowContext>();
            var service = factory.CreateOrganizationService(workflowContext.UserId);
            tracer.Trace("Create Warehouse Custom WorkFlow is invoked");
            var inputStoreName = StoreName.Get(context);
            var warehouse = new Entity("cr299_aldiwarehouse");
            warehouse["cr299_name"] = inputStoreName + " Warehouse";
            warehouse["cr299_location"] = inputStoreName;
            service.Create(warehouse);
        }
    }
}
