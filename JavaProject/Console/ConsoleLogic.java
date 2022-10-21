import JavaProject.Entities.SuperCharacter;
import JavaProject.Entities.UltraSuperPower;

public class ConsoleLogic {

    public SuperCharacter CreateSuperHero(){

        System.out.println("Inserte el nombre secreto del nuevo personaje:");
        String secretName = reader.readLine();
        SuperCharacter superCharacter = new SuperCharacter(secretName);
        
        System.out.println("Inserte el nombre conocido del nuevo personaje:");
        superCharacter.PublicName = reader.readLine();
        
        System.out.println("Inserte \"SuperHeroína\" si o \"SuperVillana\" para definir el alineamiento de " + superCharacter.PublicName + ":");
        var readLine = reader.readLine();

        if(readLine == "SuperHeroína"){
            superCharacter.Alignment = 1;
        }else if(readLine == "SuperVillana"){
            superCharacter.Alignment = 0;
        }else{
            superCharacter.Alignment = null;
        }

        readLine = 0;
        System.out.println("Inserte 1 para crear un UltraSuperPoder o 2 para crear dos SuperPoderes para " + superCharacter.PublicName + ":");
        readLine = reader.readLine();
        
        while(readLine != 1 && readLine != 2){
            System.out.println("... ... inserte 1 para crear un UltraSuperPoder o 2 para crear dos SuperPoderes para " + superCharacter.PublicName + ":");
            readLine = reader.readLine();
        }

        if(readLine == 1){
            superCharacter.SuperPowers.Add(CreateSuperPower(true));
        }else{
            superCharacter.SuperPowers.Add(CreateSuperPower(false));
            superCharacter.SuperPowers.Add(CreateSuperPower(false));
        }

        superCharacter.SetInitialStamina();

        return superCharacter;
        
    }

    public SuperPower CreateSuperPower(Boolean IsUltraSuperPower){

        SuperPower superPower = new SuperPower();

        System.out.println("Inserte el nombre del nuevo SuperPoder:");
        superPower.Name = reader.readLine();
        System.out.println("Inserte la descripción del nuevo SuperPoder:");
        superPower.Description = reader.readLine();
        System.out.println("Inserte un valor del 1 al 10 para establecer la fuerza del nuevo SuperPoder:");
        superPower.Name = reader.readLine();
        superPower.Cost = superPower.Name;

        if(IsUltraSuperPower){
            UltraSuperPower ultraSuperPower = superPower;
            ultraSuperPower.AlreadyUsed = false;
            return ultraSuperPower;
        }else{
            return superPower;
        }

    }

    public void PrintMainMenu(){
        System.out.println("1. Crear Super Personaje.");
        System.out.println("2. Listar Super Personajes.");
        System.out.println("3. Calcular Alineamiento predominante.");
        System.out.println("4. Calcular Fuerza promedio.");
        System.out.println("5. Fin.");
    }
}
