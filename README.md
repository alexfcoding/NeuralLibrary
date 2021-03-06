# NeuralLibrary

C# DLL library from scratch with demo UI app for creating, training and validation neural network models

[[Project Demo Page]](https://alexfcoding.github.io/NeuralLibrary/)

Applied as one of the methods in a [PipeMonitor](https://alexfcoding.github.io/PipeMonitor/) project for real-time object acoustic recognition with neural networks

## Features

- Building neural networks with different structure in object oriented style
- Training neural networks with a given learning rate, iterations, epochs, input signals
- Four demo learning modes included:
  - Training a model to recognize images with rotation. MNIST handwritten digits database tested (png images)
  - Training a model to recognize noisy sinusoidal signals
  - Drawing with a mouse in interactive mode to train a model to recognize any kind of user paintings
  - Signal approximation with neural network
- Validation with real-time monitoring of errors, weights values and neuron outputs on charts
- Saving pre-trained models to a file at any training state
- Loading pre-trained models from files
- DLL to use neural networks in your project
- Currently only a multilayer perceptron network is supported

#### MNIST digits and user images recognition

<img src="gifs\handwritten_digits.gif" width="285"/> <img src="gifs\icons_validation.gif" width="285"/>

#### Approximation with neural network

#### <img src="gifs\approx_sin.gif" width="773"/>

#### Quick MNIST 5 digits training/validation test: 784x50x5, 3 epochs x 1000 samples

#### Accuracy: 2329/2500 = 93,16%

![Quick MNIST 5 digits](gifs/quick_test_5.gif)

#### Full MNIST 10 digits validation: 784x400x10, 8 epochs x 50000 samples

#### Accuracy: 4776/5000 = 95,52%

![MNIST 10 digits](gifs/validation_10digits.gif)

## Run Demo App

Unpack "unpack_to_exe_folder.zip" with mnist images, user icons and pre-trained models to "Debug" and "Release" folders.

Launch "MyNeuralNetwork.sln" and compile.

- Created in Visual Studio Community 2019
- .Net Framework 4.7.2

- MathNet.Numerics is used for weights generation with normal distribution

## DLL Usage

Code example of 800x400x200x30 multilayer perceptron training on 30 different noisy signals (1 to 31Hz) with 0.005 learning rate / 5 epochs x 1000 samples

Accuracy 99,17%, see results below

```
// - Add NeuralLibrary.dll and MathNet.Numerics.dll references to project in Visual Studio
// - Add "using NeuralLibrary;"
// - Add "using MathNet.Numerics;"
// To simplify the example, each network output value corresponds to [frequency value + 1 Hz] signal class

int epochs = 5;
int iterations = 1000;
int inputNeurons = 784; // Inputs
int[] hiddenLayers = { 400, 200 }; // Two hidden layers array with 400 and 200 neurons
int outputNeurons = 30; // Outputs
Random rndClass = new Random();
Random rndAmplitude = new Random();

network = new Network(inputNeurons, hiddenLayers, outputNeurons); // Create a Network object
signal = new Signal(inputNeurons); // Create a signal object
network.LearningRate = 0.005; // Default value: 0.01

for (int i = 0; i < epochs; i++) 
{
    for (int j = 0; j < iterations; j++) 
    {
        int classToTrain = rndClass.Next(0, 30); // Randomize desired output (network performs badly without shuffling data)
        signal.GenerateSinus(classToTrain + 1, rndAmplitude); // Generate noisy amplitudes with [classToTrain + 1 Hz] freq
        network.SetTarget(classToTrain); // Set desired output and reset others
        network.SendSignalsToInputLayer(signal.Amplitude); // Send signal to input layer 
        network.Pass(); // Forward propagation -> back propagation with stochastic gradient descent  
    }
}
```

Loading images and custom training data

```
signal.ImageFromFile(pathToImage, rotateAngle); // load image according to classToTrain value        
network.SendSignalsToInputLayer(myDoubleArray); // using any double[] array with your training data      
```

Instead of Pass() method, you can call separately

```
network.ForwardPropagation();
network.FindNetworkOutputError();
network.NeuronErrorDistribution();
network.RecalculateWeights();
network.CleanOldData();
```

Get current network output values and errors

```
double[] outputs = network.CurrentNetworkOutput;
double[] errors = network.CurrentNetworkOutputError;
```

#### Code example results: training/validation on 30 noisy signal classes with 800x400x200x30 network, 5 epochs x 1000 samples

#### Accuracy: 14875/15000 = 99,17%

![Noisy signal](gifs/sin_validation.gif)

