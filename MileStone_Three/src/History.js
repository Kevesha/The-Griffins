AgentsHistory = function () {
    let self = this;
    self.id = ko.observable();
    self.hcommand = ko.observable();
    self.result =ko.observable();
    self.executionTimeStamp = ko.observable();

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