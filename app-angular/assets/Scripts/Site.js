
var cont = 0;
function CarregaAmigo() {
    $.ajax({
        method: "POST",
        url: "http://localhost:52804/token",
        contentType: "application/x-www-form-urlencoded",
        data: {
            username: $("#txbUSER").val(),
            password: $("#txbPASS").val(),
            grant_type: "password",
        },
        success: function (retorno) {
            $("#hddToken").val("");
            $("#hddToken").val(retorno.access_token);
            console.log(JSON.stringify(retorno));
            cont = 0;
            cont = parseInt(retorno.expires_in);
            CarregarAmg();
        },
        error: function (retorno) {
            $.each(retorno, function (i, item) {
                console.log(JSON.stringify(item));
                $("#lblTOKEN").text(item.error_description).css("color","rgb(233, 150, 150)");
            });

        }

    });
}

var setCont;

function CarregarAmg() {
    $.ajax({
        method: "GET",
        url: `http://localhost:52804/api/Amigos`,
        headers: { "Authorization": "Bearer " + $("#hddToken").val() },
        accepts: "application/json",
        success: function (ret) {
            console.log(ret);
            //let a = JSON.stringify(ret);
            //let b = JSON.parse("["+a+"]");
            $("#tblAMG tbody > tr").remove();
            $.each(ret, function (i, item) {
                $("#tblAMG tbody").append(`
                    <tr>                        
                        <td>${item.Nome}</td>
                        <td>${item.SobreNome}</td>
                        <td>${item.Latitude}</td>
                        <td>${item.Longitude}</td>
                        <td> <button class="btn btn-default" onclick="LocalizaAmigos(${item.Id})">Localizar</button></td>
                    </tr>
                `);
            });
        }, error: function (dados) {
            console.log(dados);
        }

    });
    
    clearInterval(setCont);
    function Limpa(){
        $("#lblTOKEN").text("");
        $("#lblTOKEN").text("Seu token expira em : " + cont).css("color","greenyellow");
       cont -= 1;
       if(cont < 0){
           $("#lblTOKEN").text("Token Expirado favor gerar um novo").css("color","orange");
           clearInterval(setCont);
       }
    }

    setCont = setInterval(Limpa, 1000);
    
    
}


function LocalizaAmigos(_id) {

    $.ajax({
        method: "GET",
        url: `http://localhost:52804/api/Amigos/`,
        headers: { "Authorization": "Bearer " + $("#hddToken").val() },
        data: { Id: _id },
        accepts: "application/json",
        success: function (ret) {
            console.log(ret);
            //let a = JSON.stringify(ret);
            //let b = JSON.parse("["+a+"]");            
            $("#tblAmigos tbody > tr").remove();
            $.each(ret, function (i, item) {
                var val = parseFloat(item.Distancia).toFixed(3);
                var r = val.replace(/[\.]/g,",");    
                $("#tblAmigos tbody").append(`
                    <tr>
                        <td><strong>${item.Nome} ${item.SobreNome}</strong> mora a <i>${r}</i> Km</td>
                    </tr>
                `);
            });
        }, error: function (dados) {
            console.log(dados);
        }

    });
}
                        //});