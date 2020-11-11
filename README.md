To easy start and test use the code below:

    var repository = new ProductPriceRepository();
    var terminal = new PointOfSaleTerminal();
    terminal.SetPricing(repository.GetProductPrices());