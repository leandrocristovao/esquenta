$(document).ready(function () {

    var controllerData = [];
    var venda = {
        ItemVenda: []
    };
    var calculo = {
        acrescimo: 0,
        desconto: 0,
        valorPago: 0,
        troco: 0,
        total: 0
    }

    $('#controller').typeahead({
        source: function (query, process) {
            return $.get('/produtos', { query: query }, function (data) {
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
        }])
        atualizaCalculo();
        $('#quantidadeModal').modal('toggle');
        $('#controller').val('');
        $('#controller').focus();
    });

    function showModalQuantidade() {
        $('#quantidadeModalQuantidade').val(1)
        $('#quantidadeModal').modal({ keyboard: true });
    };

    function findControllerData(value) {
        return $.grep(controllerData, function (n, i) {
            return n.Nome == value;
        });
    };

    function atualizaCalculo() {
        calculo.total = 0;
        venda.ItemVenda.forEach(function (obj) { calculo.total += parseFloat(obj.ValorTotal) || 0; });

        $('#lblAcrescimo').text(calculo.acrescimo.toFixed(2));
        $('#lblDesconto').text(calculo.desconto.toFixed(2));
        $('#lblValorPago').text(calculo.valorPago.toFixed(2));
        $('#lblTroco').text(calculo.troco.toFixed(2));
        $('#lblTotal').text(calculo.total.toFixed(2));
    }

    $('#quantidadeModal').on('shown.bs.modal', function () {
        $('#quantidadeModalQuantidade').focus();
        $('#quantidadeModalQuantidade').select();
    });

    $('#quantidadeModalQuantidade').keyup(function (e) {
        if (e.which == 13) {
            $('#quantidadeModalOK').trigger('click');
        }
    });
});

/**
 * 
 * $('#table').bootstrapTable('append', [{
            id: 3,
            name: 'Item 3',
            price: '$3.45'
        }])
 */