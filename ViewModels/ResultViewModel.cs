namespace ProductCatalog.ViewModels.ProductViewModels
{
    public class ResultViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}

// ViewModel -> Objetos de transporte para mostrar apenas o que se deseja a quem solicitou 