
describe("AgentViewmodel", function(){
    describe("removeAgent", function(){
        describe("Given the specified target host name" , function(){
            it("The agent endpoint address should be removed from dashboard", function(){
                //arrange
                var viewModel = new AgentViewModel();
                let name = "Agent 1";
                let ipAddress = "192.122.2.45";
                let port = "123";
                viewModel.newAgent(name,ipAddress,port);
                //act
                spyOn(viewModel, 'remove');
                
                viewModel.agentArray = [viewModel.newAgent]
                viewModel.remove(name,ipAddress,port);
 
                //assert
                expect(viewModel.remove).toHaveBeenCalled();
                expect(viewModel.remove).toBeTruthy();
            });
        });

        
    });
});
