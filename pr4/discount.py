from abc import ABC, abstractmethod

class IDiscountRule(ABC):
    @abstractmethod
    def apply(self, total):
        pass

class DiscountCalculator:
    def __init__(self):
        self.discount_rules = []

    def add_discount_rule(self, rule):
        self.discount_rules.append(rule)

    def apply_discount(self, total):
        for rule in self.discount_rules:
            total = rule.apply(total)
        return total

class PercentageDiscount(IDiscountRule):
    def __init__(self, percentage):
        self.percentage = percentage

    def apply(self, total):
        return total * (1 - self.percentage / 100)
