from abc import ABC, abstractmethod

class IPayment(ABC):
    @abstractmethod
    def process_payment(self, amount):
        pass

class CreditCardPayment(IPayment):
    def process_payment(self, amount):
        print(f"Оплата картой: {amount}")

class PayPalPayment(IPayment):
    def process_payment(self, amount):
        print(f"Оплата через PayPal: {amount}")

class BankTransferPayment(IPayment):
    def process_payment(self, amount):
        print(f"Банковский перевод: {amount}")
