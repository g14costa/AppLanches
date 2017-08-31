$(document).ready(function () {
    $('#selType').on('change', function () {
        var lanche = $('#selType').val();
        $('.unidadeIngrediente').val('0');

        if (lanche === "Personalizado")
        {
            $('.unidadeIngrediente').removeAttr('disabled');
        }
        else {
            $('.unidadeIngrediente').attr('disabled', 'disabled');
        }

        $('#valorTotalLanche').text($('#' + lanche).text())
    });

    $('.unidadeIngrediente').on('change', function () {
        var valorTotalLanche = 0;

        $('.unidadeIngrediente').each(function (i) {
            var unidades = parseFloat($(this).val());
            var valorUnitarioIngrediente = parseFloat($('#' + $(this).attr('name')).text().replace("R$ ", ""));

            valorTotalLanche += valorUnitarioIngrediente * unidades;
        });

        var quantidadeAlface = parseInt($('input[name=Alface]').val());
        var quantidadeHamburguer = parseInt($('input[name=Hamburguer]').val());
        var quantidadeQueijo = parseInt($('input[name=Queijo]').val());
        var quandidadeBacon = parseInt($('input[name=Bacon]').val());

        if (quantidadeQueijo >= 3)
        {
            //Calcula a quantidade de desconto que o lanche possui, dividindo a quantidade de Queijo por 3 e arredondando seu resultado
            //O resultado será a quantidade de vezes que será retirado o valor de um queijo do valor total do lanche
            var quantidadeDesconto = parseInt(quantidadeQueijo / 3);
            valorTotalLanche -= quantidadeDesconto * $('#Queijo').text().replace("R$ ", "");
        }
        if (quantidadeHamburguer >= 3) {
            //Calcula a quantidade de desconto que o lanche possui, dividindo a quantidade de Hamburguer por 3 e arredondando seu resultado
            //O resultado será a quantidade de vezes que será retirado o valor de um Hamburguer do valor total do lanche
            var quantidadeDesconto = parseInt(quantidadeHamburguer / 3);
            valorTotalLanche -= quantidadeDesconto * $('#Hamburguer').text().replace("R$ ", "");
        }

        if (quandidadeBacon === 0 && quantidadeAlface >= 1)
        {
            valorTotalLanche -= (valorTotalLanche / 100) * 10;
        }

        $('#valorTotalLanche').text("R$ " + valorTotalLanche.toFixed(2));
    });


});