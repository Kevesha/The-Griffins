function Agent(agentName, ipAddress, port) {

    var self = this;
    self.agentName = ko.observable(agentName);
    self.ipAddress = ko.observable(ipAddress);
    self.port = ko.observable(port);
    self.Status = ko.observable("green");
    self.showError = ko.observable(false);
    self.historyEmpty = ko.observable(false);
    self.executions = ko.observableArray([]);
    self.lastCommand = ko.observable();
    self.CommandResult = ko.observable();
    self.CommandRunTimestamp = ko.observable();

    self.IsAvailable = function (addSuccessfullAgents, doNotAddAgent) {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                addSuccessfullAgents();
            }
            else if (this.readyState == 4) {
                doNotAddAgent();
                self.showError(true);
            }
        };

        try {
            let url = "http://" + self.ipAddress() + ":" + self.port() + "/api/health";
            xhttp.open("GET", url, true);
            xhttp.send();
        } catch (e) {
            self.showError(true);
        }
        return true;
    }
    self.command = function (command, successFn, data) {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                successFn(xhttp.responseText);
            } else if (this.readyState == 4) {
                self.showError(true)
            }
        };

        try {
            let url = `http://localhost:1234/api/${command}`;
            if (command !== "script") {
                if (command === "fully Qualified hostname") {
                    url = `http://localhost:1234/api/hostname?fullyQualified=true`;
                }
                xhttp.open("GET", url, true);
                xhttp.send();
            } else {
                url = `http://localhost:1234/api/script`;
                xhttp.open("POST", url, true);
                xhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
                xhttp.send(data);
            }
        } catch (e) {
            self.showError(true)
        }
        return true;
    }

    self.insertIntoAgentDB = function (successFn, data) {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                successFn(xhttp.responseText);
            } else if (this.readyState == 4) {
                self.showError(true)
            }
        };

        try {
            let url = `http://localhost:1234/api/agentHistory`;
            xhttp.open("POST", url, true);
            xhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
            xhttp.send(data);
        }
        catch (e) {
            self.showError(true)
        }
        return true;
    }
    
    self.getHistory = function(success){
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                success(xhttp.responseText)
            } else if (this.readyState == 4) {
                alert("dont work")
            }
        };
    
        try {
            let url = `http://localhost:1234/api/agentHistory`;
            xhttp.open("GET", url, true);
            xhttp.send();
        } catch (e) {
            alert("dont work")
        }
        return true;
    }
}