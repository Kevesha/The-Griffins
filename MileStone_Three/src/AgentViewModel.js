function AgentViewModel() {
    var self = this;
    self.agentArray = ko.observableArray([]);
    self.newAgent = ko.observable(new Agent());
    self.AddAgent = ko.observable(true);
    self.Agents = ko.observable(false);

    self.ExecuteCommand = ko.observable(false);
    self.lastExecute = ko.observable();

    self.ShouldShowAgents = ko.observable(false);
    self.ShouldShowAddAgent = ko.observable(false);
    self.ShouldShowAddAgentError = ko.observable(false);
    self.ShouldShowRemoveAgents = ko.observable(false);
    self.ShouldShowAgentHistory = ko.observable(false);

    self.ShowExecuteCommand = ko.observable(false);
    self.showError = ko.observable(false);

    self.agentID = ko.observable();
    self.agentCommand = ko.observable();
    self.agentResult = ko.observable();
    self.agentExecutionTimeStamp = ko.observable();

    self.commandToRun = ko.observable();
    self.selectedAgent = ko.observable();
    self.removeAgent = ko.observable();
    self.scriptData = ko.observable();
    self.executions = ko.observableArray([]);

    self.historyArray = ko.observableArray([]);

    self.removeAgent= ko.observableArray([]);

    self.executeCommand = function () {
        let scriptJSon = {
            powerShellScript: self.scriptData()
        };

        let jsonData = JSON.stringify(scriptJSon);
        self.selectedAgent().forEach(currentSelectedAgent => {
            let currentAgent = self.agentArray().find(a => a.agentName() == currentSelectedAgent);
            currentAgent.command(self.commandToRun(), (text) => {

                let myJSON = JSON.parse(text);

                currentAgent.lastCommand(self.commandToRun());
                if (self.commandToRun() != 'script') {
                    currentAgent.CommandResult(myJSON.result);
                } else {
                    currentAgent.CommandResult(myJSON.powerShellScript);
                }
                let today = new Date();
                today.setHours(0, 0, 0, 0);
                currentAgent.CommandRunTimestamp(today)
                currentAgentJson = JSON.stringify(currentAgent);
            }, jsonData);
        });
    }
    self.ShowAddAgentDialog = function (shouldShow) {
        self.ShouldShowAddAgentError(false);
        self.ShouldShowAddAgent(shouldShow);
        self.ShouldShowAgents(!shouldShow);
        self.ShouldShowRemoveAgents(false)
        self.ShowExecuteCommand(false)
        self.ShouldShowAgentHistory(false);
    }

    self.ShowAgentHistory = function (shouldShow) {
        self.ShouldShowAgents(false);
        self.ShouldShowAgentHistory(shouldShow);
        let test = new AgentsHistory();

        test.getHistory((payload)=>{
            self.historyArray(JSON.parse(payload));
        });
    }

    self.addAgent = function () {
        var agent = new Agent(self.newAgent().agentName(), self.newAgent().ipAddress(), self.newAgent().port());
        if (self.newAgent().agentName() === undefined && self.newAgent().ipAddress() === undefined && self.newAgent().port() === undefined) {
            self.showError(true);
        } else {
            let addSuccessfullAgents = function () {
                self.agentArray.push(agent);
                viewAgentViewModel.ShowAddAgentDialog(false);
                viewAgentViewModel.showError(false);
            };
            agent.IsAvailable(addSuccessfullAgents);
        }
        self.AddAgent(false);
        self.Agents(true);
    };

    self.remove = function () {
        self.agentArray.remove(function (agentArray) {
            return agentArray.agentName() == self.newAgent().agentName();
        });

    };

    self.execute = function () {
        self.ExecuteCommand = ko.observable(true);
        self.AddAgent = ko.observable(false);
        self.Agents = ko.observable(true);
    };

    window.setInterval(function () {
        self.agentArray().forEach(agent => {
            let pass = function () {
                agent.Status("green");
            }
            let fail = function () {
                agent.Status("red");
            }
            agent.IsAvailable(pass, fail);
        });
    }, 10000);
};


var viewAgentViewModel = new AgentViewModel();
ko.applyBindings(viewAgentViewModel);