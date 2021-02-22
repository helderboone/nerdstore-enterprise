using FluentValidation;
using System;

namespace NSE.Carrinho.API.Model
{
    public class CarrinhoItem
    {
        public CarrinhoItem()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Valor { get; private set; }
        public string Imagem { get; private set; }
        public Guid CarrinhoId { get; private set; }
        public CarrinhoCliente CarrinhoCliente { get; private set; }

        internal void AssociarCarrinho(Guid carrinhoId)
        {
            CarrinhoId = carrinhoId;
        }

        internal decimal CalcularValor()
        {
            return Quantidade * Valor;
        }

        internal void AdicionarUnidades(int unidades)
        {
            Quantidade += unidades;
        }

        internal void AtualizarUnidades(int unidades)
        {
            Quantidade = unidades;
        }

        internal bool EhValido()
        {
            return new ItemPedidoValidation().Validate(this).IsValid;
        }

        public class ItemPedidoValidation : AbstractValidator<CarrinhoItem>
        {
            public ItemPedidoValidation()
            {
                RuleFor(c => c.ProdutoId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do produto inválido");

                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .WithMessage("O nome do produto não foi informado");


                RuleFor(c => c.Quantidade)
                    .GreaterThan(0)
                    .WithMessage("A quantidade mínima de um Item é 1");

                RuleFor(c => c.Quantidade)
                    .LessThan(CarrinhoCliente.MAX_QUANTIDADE_ITEM)
                    .WithMessage($"A quantidade máxima de um Item é {CarrinhoCliente.MAX_QUANTIDADE_ITEM}");


                RuleFor(c => c.Valor)
                    .GreaterThan(0)
                    .WithMessage("O valor do item precisa ser maior que 0");
            }
        }
    }
}
