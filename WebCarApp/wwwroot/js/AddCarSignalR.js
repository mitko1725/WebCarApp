
let connection = null;

setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/CarHub")
        .build();

   
    connection.on("NewOrder", function () {
        $('.alert').toast({ delay: 25000 });
        $('.alert').toast('show');

    });

    connection.on("Finished", function () {
        // connection.stop();
    });

    connection.start()
        .catch(err => console.error(err.toString()));
};


setupConnection();

