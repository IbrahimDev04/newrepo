namespace EcoCoinUni.Dtos.PaymentDtos
{
    public class GetHistoryDto
    {
        public int cardNumber { get; set; }
        public DateTime date { get; set; }
        public string fullName { get; set; }
        public int tokenCount { get; set; }
        public double tokenPrice { get; set; }
    }
}
