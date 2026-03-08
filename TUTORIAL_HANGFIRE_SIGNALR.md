# Tutorial: Background Jobs & Real-Time / Tarefas em Segundo Plano e Tempo Real

## Hangfire (Background Jobs)

We use Hangfire to run tasks in the background. Be it fire-and-forget or recurring jobs.
Usamos Hangfire para tarefas em segundo plano. Seja "fire-and-forget" ou recorrentes.

### How to Schedule a Job / Como Agendar um Job

In `Program.cs` or inside a Service:

**Fire-and-Forget (Run once immediately):**
```csharp
BackgroundJob.Enqueue(() => Console.WriteLine("Job executed!"));
```

**Recurring Job (Run repeatedly):**
```csharp
RecurringJob.AddOrUpdate("my-job-id", () => MyMethod(), Cron.Daily);
```

### Dashboard
Access `/hangfire` to see the status of your jobs.

---

## SignalR (Real-Time Communication)

We use SignalR to push updates to the frontend (e.g., Angular, React, Blazor).
Usamos SignalR para enviar atualizações para o frontend.

### Server Side (Backend)
1. Inject `INotifier` into your Handler or Service.
2. Call `await _notifier.NotifyAsync("Message");`.

The `NotifierService` (in API) sends the message using standard SignalR methods:
```csharp
await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
```

### Client Side (Frontend Example)
Use the `@microsoft/signalr` package via npm.

```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/notificationHub")
    .build();

connection.on("ReceiveMessage", (message) => {
    console.log("New notification:", message);
});

connection.start();
```
