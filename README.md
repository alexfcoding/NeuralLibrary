# NeuralLibrary

C# DLL library with demo UI app for creating, training and validation neural network models

## Features 

- Creating neural network models with variable structure in object oriented style
- Training neural networks with with a given learning rate, iterations, epochs, input signals
- Three demo learning modes included:
  - Training models to recognize images with rotation. MNIST handwritten digits database tested (png format)
  - Drawing with mouse in interactive mode to train model recognition of any kind of user paintings
  - Training models to recognize noisy sinusoidal signals
- Validation with real-time monitoring of errors, weights values and neuron outputs on charts
- Saving pre-trained models to file at any training state
- Loading pre-trained models from files
- DLL library to use neural networks in your project

Created from scratch for educational purposes.

Used in [LINK] project to recognize controlled object state by vibroacoustic signals.

## Results on MNIST database with 10 chars

## DLL Usage

Example of creating and training 784x200x100x50x10 perceptron with 0.05 learning rate

```
int inputNeurons = 784; // Inputs
int[] hiddenLayers = {200, 100, 50}; // Hidden layers array
int outputNeurons = 10; // Outputs
double learningRate = 0.05; // Learning rate

network = new Network(outputNeurons, learningRate); // Create new Network object with 10 outputs
network.CreateInputLayer(inputNeurons, hiddenLayers[0]); // Create input layer, connected to first hidden
network.CreateHiddenLayers(hiddensLayers, outputNeurons); // last is connected to output
network.CreateOutputLayer(outputNeurons, 0); // Create output layer

signal = new Signal(inputNeurons); // Create signal object
signal.ImageFromFile(pathToRandomImage, rotateAngle); // Fill image signal
signal.GenerateSinus(frequency, rndAmplitude); // Or generate amplitudes

network.SendSignalsToInputLayer(signal.Amplitude); // Send signals to input layer 
network.ForwardPropagation(); // Forward propagation;
network.FindNetworkOutputError(); // Calculate output
network.NeuronErrorDistribution(); // Check errors
network.RecalculateWeights(); // Back propagation with stochastic gradient descent
network.CleanOldData; // Cleanup before next pass
```
