# Simulacion_Rutas_reparticion
This is a project for designing routes for on demand buyers
 
 # installation
 firts clone the git repo to your local machine 
 
 ```
 git clone https://github.com/Virgilio-AI/Simulacion_Rutas_reparticion.git
 ```
 
 
 # usage
 now open it with visual studio or just run the executable
 
 ```
 cd Simulacion_Rutas_reparticion

 mono /bin/Debug/net6.0/holaMundo.exe
 ```
 
 
 # screen shots
 
 ## ejemplo de simulacion exitosa
![simulacion_exitosa](https://user-images.githubusercontent.com/59902976/168459742-a29248e1-fade-4e27-a7f9-f9c0f284a934.png)
## ejemplo de bitacora mostrandose
![bitacora](https://user-images.githubusercontent.com/59902976/168459750-41f9fbab-a82c-4d20-96ba-3a97e87bd02e.png)


# patrones creacionales
el patron creacional que use fue el factory ya que es aplicado en muchas funciones que para reducir la complejiadad llamamos a travez de una interfaz

tambien en este proyecto use el patron singleton que es instanciado una sola vez y es global para todas las clases. cuando se quiere leer el archivo json
### imagen de la clase que es instanciada como singleton
![image](https://user-images.githubusercontent.com/59902976/168460075-21c6d926-a374-4532-b281-b77892daeea8.png)

# patrones estructurales
for the structural pattern I used the facade pattern. when calling the external class I use the facade to facilitate 
the usage of writing and reading tex/json files as a whole
so I just do something like this:
### imagen del facade
![image](https://user-images.githubusercontent.com/59902976/168460568-ab1b9465-d8b3-4282-8049-bd7b8c3d37eb.png)
### instead of something like this
![image](https://user-images.githubusercontent.com/59902976/168460592-0cc6216f-3fef-4f2e-a792-d8103b90aeaf.png)



# patrones de comportamiento
for the behavioral patterns I used the iterator pattern since 
the objects tend to be very ambiguous I just used a dynamic and iterating over it 
without messing about the time of class
![image](https://user-images.githubusercontent.com/59902976/168460717-6cac97ee-e237-4272-b067-f10d4cc0a3fe.png)
