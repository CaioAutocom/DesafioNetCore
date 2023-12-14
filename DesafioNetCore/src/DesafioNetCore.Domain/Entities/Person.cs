using DesafioNetCore.Domain.Entities.Common;

namespace DesafioNetCore.Domain.Entities
{

    public class Person : EntityBase
    {
        public required string Name { get; set; }
        public string Document { get; set; } = string.Empty;
        public required string Town { get; set; } = string.Empty;
        public bool CanBuy { get; set; }
        public string Observations { get; set; } = string.Empty;
        public string AlternativeIdentifier { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
    }
}

/*Pessoas
* Teremos um cadastro de pessoas que terá os campos, Nome completo, documento, nome da cidade.ativo, liberado venda, observações, código alternativo.
* Código Alternativo e Documento que deverá ser aceito somente CPF ou CNPJ válidos e não poderam se repetir.Ou seja cada pessoa somente poderá ter um número de documento e um código alternativo. Ambos podem ser vazios.
* A pessoa a ser incluida deve ter sua propriedade ativo como verdadeiro e sua propriedade liberado venda como falso.
* Nome completo e nome da cidade não podem ser vazios.
* Poderá existir pessoa homonimas no cadastro.
* Somente usuários que não sejam Vendedores podem excluir uma pessoa, desde que liberado venda esteja como false.
* Somente usuários do tipo Administradores ou Gerentes podem liberar a pessoa para venda.
* Somente usuários do tipo Administradores ou Gerentes podem desativar uma pessoa.
* Toda pessoa já será considaderada um cliente desde que liberado para venda.*/




