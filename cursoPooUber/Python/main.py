from car import Car
if __name__ == "__main__":
    print("hola mundo")
    car = Car()
    car.license = "ADS123"
    car.driver= "Andres Herrera"
    print(vars(car))

    car2 = Car()
    car2.license = "KJN123"
    car2.driver= "Andrea Herrera"
    print(vars(car2))