 
## Installation
1. Clone the repository:
```bash
 git clone https://github.com/yourusername/yourproject.git
```
2. Install .net Core SDK:
```bash
 https://dotnet.microsoft.com/en-us/download/dotnet/8.0
```
# Requirements to run this project.
- `.Net Core 8 SDK`.
- `No specific operating system needed `.

# How It Works.
- **First Step**: We should create a new Workato recipe that triggers the order creation/update process based on a specific event or schedule.
- **Second Step**: We should use Workato's HTTP connector to interact with this project's endpoints `CreateOrUpdateOrderAsync` or `GetOrdersAsync`".
- **Third Step**: We should be receiving requests from Workato asking  to create order or modify order.
# Notes.
-  This is just a simple example of how we can implement a simple request to receive data from Workato and request ShipStation to ask for order  creation or modification and handle the response and the exception.
- It is always going to return 401 Not Authorized because I don't have valid credentials to access ShipStation.
- In a real scenario, the requests to this API must be authenticated and protected.


# Project structure.
- Core
  - HttpConfig.cs
- ShipStation
    - Models
        - BaseResult.cs
    - ShipStationIntegration.cs
- Program.cs

