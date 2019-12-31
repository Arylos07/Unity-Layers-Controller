# Unity Layers Controller 

This is the user guide to the Layers class for managing object layers. There are many overflow methods to allow flexibility. Overflows are listed below the parent function.

## ChangeCullingMask(string layerName, bool visible)

Changes the culling mask on the main camera by toggling the layer layerName. The boolean visible notates the state; if true, the layer will be enabled on the camera. If false, the layer will be disabled.

### ChangeCullingMask(string layerName, bool visible, Camera camera)

Overflow to ChangeCullingMask(). Designate a camera to adjust instead of the main camera.