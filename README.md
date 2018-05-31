User Story 1: Agent Maintenance
```
As a user 
I want a dashboard 
So that I can view, add, update ,delete and check
the status of the agents
```


User behaviour Scenarios

```
Given the agent name, ip address And port number
When clicking the Save button
Then the new agent should be added
```

```
Given the agent name
When clicking the Remove button
Then the agent should be removed
```

```
Given the agent name, ip address and port number
When clicking the Update button
Then the information for agent should be updated
```

```
Given any information
When clicking the Cancel button
Then should undo all the changes and go back to dashboard
```

```
Given the health endpoint of the agent
When I view the dashboard
Then I should view the status
```

User Story 2: Agent Execution
```
As a user 
I want to execute a command
So that I can see the details of the machine I am using.
```

User behaviour Scenarios

```
Given an ajax request,
When sending the "hostname" command
Then the computer name should be returned
```

```
Given an ajax request,
When sending the "ip" command
Then the computer's IP address should be returned

```

```
Given an ajax request,
When sending the "os" command
Then the computer's operating system should be returned

```

```
Given an ajax request,
When sending the "hostname" command with the `-f` or `--fully-qualified` options
Then the fully qualified computer name should be returned

```



