Simple checkout library that prices supermarket SKUs while supporting volume offers. Built with focus on clean separation between pricing data, calculation strategies, and the checkout workflow. Tests are written with xUnit.

## Projects
- Checkout.Core – core library exposing `ICheckout`, pricing strategies, and pricing catalogue.
- Checkout.Core.Tests – xUnit module covering pricing logic & offer scenarios.

## Design Overview
- `CheckoutService` maintains the basket and defers price calculation to policies supplied via `PricingCatalogue`.
- Each `PricingPolicy` ships with an `IPricingStrategy`, allowing easy extension for future promotions.
- Current strategies include a straightforward per-unit calculator and a bundle-discount calculator.

Test coverage is tracked via a simple GitHub Actions flow.