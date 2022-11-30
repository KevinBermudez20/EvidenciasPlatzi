 class Main {
    public static void main(String[] args){
      System.out.println("hola mundo");
      UberX uberX = new UberX("amq123", new Driver("Andres Herrera", "AND123" ), "chevrolet", "spark");
      uberX.setPassenger(3);
      uberX.printDaraCar();

      UberX uberX2 = new UberX("VCC456", new Driver("Andrea Herrera", "ANA123" ), "chevrolet", "onix");
      // uberX2.passenger= 3;
      uberX2.printDaraCar();

      
    }
 }