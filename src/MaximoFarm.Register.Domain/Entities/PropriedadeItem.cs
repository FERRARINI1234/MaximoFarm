namespace MaximoFarm.Register.Domain.Entities
{
    public class PropriedadeItem
    {
        public int CodTalhao { get; set; }
        public decimal AreaTotal { get; set; }
        public decimal AreaProdutiva { get; set; }
        public decimal AreaDano { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public int CodPropriedade { get; set; }
        public Propriedade Propriedade { get; set; }

        public PropriedadeItem()
        {
        }
    }
}
