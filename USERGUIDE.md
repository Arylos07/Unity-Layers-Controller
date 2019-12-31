# Unity Layers Controller version 1.0#1

This is the user guide to the Layers class for managing object layers. There are many overflow methods to allow flexibility. Overflows are listed below the parent function.

# Changing Culling Mask

## ChangeCullingMask(string layerName, bool visible)

Changes the culling mask on the main camera by toggling the layer layerName. The boolean visible notates the state; if true, the layer will be enabled on the camera. If false, the layer will be disabled.

### ChangeCullingMask(string layerName, bool visible, Camera camera)

Overflow to ChangeCullingMask(). Designate a camera to adjust instead of the main camera.

# Checking Layer state

## IsLayerRendered(int layer)

Returns state of the given layer on the main camera. This function does not take layer names and only takes integers.

### IsLayerRendered(int layer, Camera camera)

Return state of the given layer on the given camera. This function does not take layer names and only takes integers.

# Setting layer of objects

## SetLayer(GameObject obj, int newLayer)

Manually sets the layer of the given object to the given integer layer. This does not affect children.

### SetLayer(GameObject obj, string newLayer)

Manually sets the layer of the given object to the given layer by name. This does not affect children.

## SetLayerRecursively(GameObject obj, int newLayer)

Sets the layer of the given object and all of its children to the given integer layer.

### SetLayerRecursively(GameObject obj, string newLayer)

Sets the layer of the given object and all of its children to the given layer name.

### SetLayerRecursively(GameObject obj, int newLayer, string ignoreObjectName)

Sets the layer of the given object and its children to the given integer layer. This function will ignore any objects with the name specified. (Instantiated objects may not apply without the " (clone)" suffix).

### SetLayerRecursively(GameObject obj, string newLayer, string ignoreObjectName)

Sets the layer of the given object and its children to the given layer name. This function will ignore any objects with the name specified. (Instantiated objects may not apply without the " (clone)" suffix).

### SetLayerRecursively(GameObject obj, int newLayer, string[] ignoreObjectName)

Sets the layer of the given object and its children to the given integer layer. This function will ignore any objects with names in the given array.

### SetLayerRecursively(GameObject obj, string newLayer, string[] ignoreObjectName)

Sets the layer of the given object and its children to the given layer name. This function will ignore any objects with names in the given array.

### SetLayerRecursively(GameObject obj, int newLayer, List<string> ignoreObjectName)

Sets the layer of the given object and its children to the given integer layer. This function will ignore any objects with names in the given list.

### SetLayerRecursively(GameObject obj, string newLayer, List<string> ignoreObjectName)

Sets the layer of the given object and its children to the given layer name. This function will ignore any objects with names in the given list.