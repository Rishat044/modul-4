from abc import ABC, abstractmethod

class IDelivery(ABC):
    @abstractmethod
    def deliver_order(self, order):
        pass

class CourierDelivery(IDelivery):
    def deliver_order(self, order):
        print("Заказ доставлен курьером.")

class PostDelivery(IDelivery):
    def deliver_order(self, order):
        print("Заказ отправлен почтой.")

class PickUpPointDelivery(IDelivery):
    def deliver_order(self, order):
        print("Заказ готов к получению в пункте выдачи.")
