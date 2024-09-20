from abc import ABC, abstractmethod

class INotification(ABC):
    @abstractmethod
    def send_notification(self, message):
        pass

class EmailNotification(INotification):
    def send_notification(self, message):
        print(f"Email уведомление: {message}")

class SmsNotification(INotification):
    def send_notification(self, message):
        print(f"SMS уведомление: {message}")
