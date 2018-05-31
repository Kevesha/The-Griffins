
describe("AgentViewmodel", function () {
    beforeEach(() => {
        //jasmine.Ajax.install();
    });
    afterEach(() => {
       // jasmine.Ajax.uninstall();
    });
    describe("addAgent", function () {
       
        describe("When agent name ,ip address and port are empty", function () {

            it("should add nothing to the agent array ", function () {
                let agentName="";
                let ipAddress="";
                let port="";
                setupAjaxRequest(404);
                let viewModel = new AgentViewModel();
                 viewModel.newAgent(agentName,ipAddress,port);
               
               spyOn(viewModel, 'addAgent');
       
               viewModel.addAgent();
       
               expect(viewModel.addAgent).toHaveBeenCalled();
               expect(viewModel.agentArray.length).toBe(0);
       
           });

        });
    
    });
});

function setupAjaxRequest(status) {
   // jasmine.Ajax.stubRequest("http://localhost:1234/api/health").andReturn({
      //  "status": status
   // });
}
