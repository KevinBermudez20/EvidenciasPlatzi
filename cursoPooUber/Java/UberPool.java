public class UberPool extends Car {

    String brand;
    String model;
    private Integer passenger;
    public UberPool(String license, Account driver , String brand, String model) {
        super(license, driver);
        this.brand = brand;
        this.model = model;
    }

    @Override
    public void setPassenger(Integer passenger){
        if (passenger == 6) {
            this.passenger = passenger;
        }else{
            System.out.println("minimo 4 pasajeros");
        }
        
    }
    
} 
