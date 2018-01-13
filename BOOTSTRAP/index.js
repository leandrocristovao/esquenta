$(document).ready(function () {

    var controllerData = [];
    var venda = {
        ItemVenda: []
    };

    var calculo = {
        acrescimo: 0,
        desconto: 0,
        valorPago: 0,
        valorCC: 0,
        valorCD: 0,
        valorD: 0,
        troco: 0,
        total: 0
    }

    $('#controller').typeahead({
        source: function (query, process) {
            return $.get('/produtos', {
                query: query
            }, function (data) {
                controllerData = data;
                var results = _.map(data, function (d) {
                    return d.Nome;
                });
                return process(results);
            });
        },
        afterSelect: function (item) {
            showModalQuantidade();
        }
    });

    $('#table').bootstrapTable({
        columns: [{
            field: 'id',
            title: 'ID'
        }, {
            field: 'produto',
            title: 'Produto'
        }, {
            field: 'quantidade',
            title: 'Quantidade'
        }, {
            field: 'valor',
            title: 'Valor Unit.'
        }, {
            field: 'valorTotal',
            title: 'Valor'
        }],
        data: []
    });

    $('#controller').keyup(function (e) {
        if (e.which == 13) {
            showModalQuantidade();
        }
    });

    $('#quantidadeModalOK').click(function (e) {
        var item = $('#controller').val();
        var quantidade = $('#quantidadeModalQuantidade').val();
        item = findControllerData(item)[0];

        var itemVenda = {
            Valor: item.Valor,
            ValorTotal: item.Valor * quantidade,
            Quantidade: quantidade,
            Produto: item
        };
        venda.ItemVenda.push(itemVenda);

        $('#table').bootstrapTable('append', [{
            id: venda.ItemVenda.length,
            produto: itemVenda.Produto.Nome,
            valor: itemVenda.Valor,
            quantidade: itemVenda.Quantidade,
            valorTotal: itemVenda.ValorTotal
        }]);

        atualizaCalculo();
        $('#quantidadeModal').modal('toggle');
        $('#controller').val('');
        $('#controller').focus();
    });

    $('#btnCalcular').click(function (e) {
        $('#calculadoraModal').modal({
            keyboard: true
        });
    });

    $('#btnCancelar').click(function (e) {

    });

    $('#btnFechar').click(function (e) {

    });
    $('#calculadoraModalOK').click(function (e) {
        calculo.acrescimo = toDecimal($('#calculadoraModalAcrescimo').val());
        calculo.desconto = toDecimal($('#calculadoraModalDesconto').val());
        calculo.valorCC = toDecimal($('#calculadoraModalCC').val());
        calculo.valorCD = toDecimal($('#calculadoraModalCD').val());
        calculo.valorD = toDecimal($('#calculadoraModalD').val());
        calculo.valorPago = calculo.valorCC + calculo.valorCD + calculo.valorD;

        $('#calculadoraModal').modal('toggle');
        atualizaCalculo();
    });

    $('#quantidadeModal').on('shown.bs.modal', function () {
        $('#quantidadeModalQuantidade').focus();
        $('#quantidadeModalQuantidade').select();
    });

    $('#calculadoraModal').on('shown.bs.modal', function () {
        $('#calculadoraModalDesconto').focus();
    });

    $('#quantidadeModalQuantidade').keyup(function (e) {
        if (e.which == 13) {
            $('#quantidadeModalOK').trigger('click');
        }
    });

    function showModalQuantidade() {
        $('#quantidadeModalQuantidade').val(1)
        $('#quantidadeModal').modal({
            keyboard: true
        });
    }

    function findControllerData(value) {
        return $.grep(controllerData, function (n, i) {
            return n.Nome == value;
        });
    }

    function toDecimal(value) {
        value = parseFloat(value.replace('.', '').replace(',', '.'));
        value = (isNaN(value) ? 0 : value)

        return value;
    }

    function atualizaCalculo() {
        calculo.total = 0;
        venda.ItemVenda.forEach(function (obj) {
            calculo.total += parseFloat(obj.ValorTotal) || 0;
        });

        $('#lblAcrescimo').text(calculo.acrescimo.toFixed(2));
        $('#lblDesconto').text(calculo.desconto.toFixed(2));
        $('#lblValorPago').text(calculo.valorPago.toFixed(2));
        $('#lblTroco').text(calculo.troco.toFixed(2));
        $('#lblTotal').text(calculo.total.toFixed(2));
    }

    /**
     * Formata a entrada de texto das caixas de texto da janela CALCULADORA
     */
    $('.currency').inputmask("numeric", {
        radixPoint: ",",
        groupSeparator: ".",
        digits: 2,
        autoGroup: true,
        rightAlign: true,
        oncleared: function () {
            if (self != null)
                self.Value('');
        }
    });

    /**
     * Navega pelas caixas de texto da janela CALCULADORA com a tecla ENTER
     */
    $('.currency').keyup(function (e) {
        if (e.which == 13) {
            var index = $('.currency').index(this) + 1;
            $('.currency').eq(index).focus();
        }
    });


    window.onkeydown = evt => {
        var F7 = 118;
        var F8 = 119;
        var F9 = 120;

        switch (evt.keyCode) {
            case F7:
                $('#btnCalcular').trigger('click');
                break;

            case F8:
                $('#btnCancelar').trigger('click');
                break;

            case F9:
                $('#btnFechar').trigger('click');
                break;

                //Fallback to default browser behaviour
            default:
                return true;
        }
        //Returning false overrides default browser event
        return false;
    };

});